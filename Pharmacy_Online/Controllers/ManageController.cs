using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Pharmacy_Online.Data_Access_Layer;
using Pharmacy_Online.Models;
using Pharmacy_Online.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Pharmacy_Online.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ProductsContext _db = new ProductsContext();

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
            => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary) TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
            {
                ViewBag.UserIsAdmin = false;
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageCredentialsViewModel
            {
                Message = message,
                UserData = user.UserData
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "UserData")] UserData userdata)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserData = userdata;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(
            [Bind(Prefix = "ChangePasswordViewModel")] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var result =
                await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }

                return RedirectToAction("Index", new {Message = ManageMessageId.ChangePasswordSuccess});
            }

            AddErrors(result);

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new {Message = message});
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie,
                DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties {IsPersistent = isPersistent},
                await user.GenerateUserIdentityAsync(UserManager));
        }

        public ActionResult OrderList()
        {
            bool IsAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = IsAdmin;

            IEnumerable<Order> userOrders;

            // return all orders for admin
            if (IsAdmin)
            {
                userOrders = _db.Orders.Include("OrderPositions").OrderByDescending(n => n.OrderTime).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();

                userOrders =
                    _db.Orders.Where(n => n.UserId == userId)
                        .Include("OrderPositions")
                        .OrderByDescending(n => n.OrderTime)
                        .ToArray();
            }

            return View(userOrders);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public OrderStatus ChangeOrderStatus(Order order)
        {
            Order toChange = _db.Orders.Find(order.OrderId);
            if (toChange != null) toChange.OrderStatus = order.OrderStatus;
            _db.SaveChanges();

            return order.OrderStatus;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct(int? productId, bool? confirm)
        {
            Product product;
            if (productId.HasValue)
            {
                ViewBag.EditMode = true;
                product = _db.Products.Find(productId);
            }
            else
            {
                ViewBag.EditMode = false;
                product = new Product();
            }

            var result = new EditProductViewModel
            {
                Categories = _db.Categories.ToList(),
                Product = product,
                Confirm = confirm,
                Products = _db.Products.Where(a=>a.Hidden).ToList(),
                
                
            };

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct(EditProductViewModel model, HttpPostedFileBase file)
        {
            if (model.Product.ProductId > 0)
            {
                //product modification
                _db.Entry(model.Product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("AddProduct", new {confirm = true});

            }
            if (file != null && file.ContentLength > 0)
            {
                if (ModelState.IsValid)
                {
                    //var fileExt = Path.GetExtension(file.FileName);
                    //var filename = Guid.NewGuid() + fileExt;
                    var filename = Path.GetFileName(file.FileName);

                    if (filename != null)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Products"), filename);
                        file.SaveAs(path);
                    }

                    model.Product.ImageFile = filename;
                    model.Product.AddTime = DateTime.Now;

                    _db.Entry(model.Product).State = EntityState.Added;
                    _db.SaveChanges();

                    return RedirectToAction("AddProduct", new {confirm = true});
                }
                var categories = _db.Categories.ToList();

                model.Categories = categories;

                var product = _db.Products.Where(a => a.Hidden).ToList();

                model.Products = product;

                return View(model);
            }

            else
            {
                ModelState.AddModelError("", "Nie wskazano pliku !");

                var categories = _db.Categories.ToList();

                model.Categories = categories;

                var product = _db.Products.Where(a => a.Hidden).ToList();

                model.Products = product;

                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowProduct(int productId)
        {
            var product = _db.Products.Find(productId);
            if (product != null) product.Hidden = false;
            _db.SaveChanges();

            return RedirectToAction("AddProduct", "Manage", new {confirm = true});
        }

        [Authorize(Roles = "Admin")]
        public ActionResult HideProduct(int productId)
        {
            var product = _db.Products.Find(productId);
            if (product != null) product.Hidden = true;
            _db.SaveChanges();

            return RedirectToAction("AddProduct", "Manage", new { confirm = true });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowHiddenList()
        {
            var product = _db.Products.Where(a => a.Hidden);

            return View(product);




        }



    }
}