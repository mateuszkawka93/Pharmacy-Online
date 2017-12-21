using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Pharmacy_Online.Data_Access_Layer;
using Pharmacy_Online.Infrastructure;
using Pharmacy_Online.Models;
using Pharmacy_Online.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Pharmacy_Online.Controllers
{
    public class CartController : Controller
    {
        private CartManager _cartManager;
        private ISessionManager SessionManager { get; set; }
        private ProductsContext _db = new ProductsContext();

        public CartController()
        {
            SessionManager = new SessionManager();
            _cartManager = new CartManager(SessionManager, _db);
        }


        public ActionResult Index()
        {
            var cartposition = _cartManager.GetCart();
            var totalprice = _cartManager.GetCartValue();

            CartViewModel cartvm = new CartViewModel()
            {
                CartPositions = cartposition,
                TotalPrice = totalprice,
            };

            return View(cartvm);
        }

        public ActionResult AddToCart(int id)
        {
            _cartManager.AddToCart(id);

            return RedirectToAction("Index");
        }

        public int GetItemAmount()
        {
            return _cartManager.GetCartPositionAmount();
        }

        public ActionResult RemoveFromCart(int productId2)
        {
            int positionamount = _cartManager.RemoveFromCart(productId2);
            int cartpositionamount = _cartManager.GetCartPositionAmount();
            decimal cartvalue = _cartManager.GetCartValue();

            var result = new CartRemoveViewModel
            {
                IdRemoveItem = productId2,
                RemovingPositionAmount = positionamount,
                CartTotalValue = cartvalue,
                CartPositionAmount = cartpositionamount
            };

            return Json(result);

        }

        public async Task<ActionResult> Purchase()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order()
                {
                    Name = user.UserData.Name,
                    Surname = user.UserData.Surname,
                    Address = user.UserData.Address,
                    City = user.UserData.City,
                    PostCode = user.UserData.PostCode,
                    Email = user.UserData.Email,
                    Phone = user.UserData.Phone
                };


               return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new {returnUrl = Url.Action("Purchase", "Cart")});
            }
        }

        [HttpPost]
        public async Task<ActionResult> Purchase(Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var neworder = _cartManager.CreateOrder(orderDetails, userId);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                _cartManager.EmptyCart();

                var order =
                    _db.Orders.Include("OrderPositions")
                        .Include("OrderPositions.Product")
                        .SingleOrDefault(a => a.OrderId == neworder.OrderId);

                ConfirmOrderEmail email = new ConfirmOrderEmail
                {
                    To = order.Email,
                    From = "matizekjj21@gmail.com",
                    TotalValue = order.OrderValue,
                    OrderNumber = order.OrderId,
                    OrderPositions = order.OrderPositions
                };
                email.Send();



                return RedirectToAction("ValidateOrder");

            }
            else
            {
                return View(orderDetails);
            }
        }


        public ActionResult ValidateOrder(Order orderDetails)
        {
           
            return View();
        }
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

       
    }
}