using Pharmacy_Online.Data_Access_Layer;
using Pharmacy_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy_Online.Infrastructure
{
    public class CartManager
    {
        private ProductsContext _db;
        private ISessionManager _session;

        public CartManager(ISessionManager _session, ProductsContext _db)
        {
            this._session = _session;
            this._db = _db;
        }

        public List<CartPosition> GetCart()
        {
            List<CartPosition> cart;

            if (_session.Get<List<CartPosition>>(Consts.CartSessionKey) == null)
            {
                cart = new List<CartPosition>();
            }
            else
            {
                cart = _session.Get<List<CartPosition>>(Consts.CartSessionKey);
            }
            return cart;
        }

        public void AddToCart(int productId)
        {
            var cart = GetCart();

            var cartPosition = cart.Find(k => k.Product.ProductId == productId);

            if (cartPosition != null)
            {
                cartPosition.Amount++;
            }
            else
            {
                var productToAdd = _db.Products.SingleOrDefault(k => k.ProductId == productId);

                if (productToAdd != null)
                {
                    var newCartPosition = new CartPosition()
                    {
                        Product = productToAdd,
                        Amount = 1,
                        Value = productToAdd.Price
                    };
                    cart.Add(newCartPosition);
                }
            }

            _session.Set(Consts.CartSessionKey, cart);
        }

        public int RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var cartPosition = cart.Find(k => k.Product.ProductId == productId);

            if (cartPosition != null)
            {
                if (cartPosition.Amount > 1)
                {
                    cartPosition.Amount--;
                    return cartPosition.Amount;
                }

                else
                {
                    cart.Remove(cartPosition);
                }
            }

            return 0;


        }

        public decimal GetCartValue()
        {
            var cart = GetCart();
            return cart.Sum(k => k.Amount*k.Product.Price);
        }

        public int GetCartPositionAmount()
        {
            var cart = GetCart();
            var amount = cart.Sum(k => k.Amount);
            return amount;
        }

        public Order CreateOrder(Order neworder, string userId)
        {
            var cart = GetCart();
            neworder.OrderTime = DateTime.Now;
            neworder.UserId = userId;

            _db.Orders.Add(neworder);

        
            if (neworder.OrderPositions ==null)

                    neworder.OrderPositions = new List<OrderPosition>();
            decimal cartValue = 0;

            foreach (var cartElement in cart)
            {
                var newOrderPosition = new OrderPosition()
                {
                    ProductId = cartElement.Product.ProductId,
                    Amount = cartElement.Amount,
                    OrderPrice = cartElement.Product.Price
                };

                cartValue += cartElement.Amount*cartElement.Product.Price;
                neworder.OrderPositions.Add(newOrderPosition);
            }

            neworder.OrderValue = cartValue;
            _db.SaveChanges();

            return neworder;
        }

        public void EmptyCart()
        {
            _session.Set<List<CartPosition>>(Consts.CartSessionKey, null);
        }
    }
}