using Pharmacy_Online.Data_Access_Layer;
using System.Linq;
using System.Web.Mvc;

namespace Pharmacy_Online.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsContext _db = new ProductsContext();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string categoryname, string searchQuery = null)
        {

            
            var categorylist =
                _db.Categories.Include("Products").Single(n => n.Name.ToUpper() == categoryname.ToUpper());

            var product = categorylist.Products.Where(a => (searchQuery == null ||
                                                                a.Name.ToLower().Contains(searchQuery.ToLower()) ||
                                                                a.Producer.ToLower().Contains(searchQuery.ToLower())) &&
                                                               !a.Hidden);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductsList", product);
            }

            return View(product);
        }

        public ActionResult Details(int id)
        {

            var product = _db.Products.Find(id);
            return View(product);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult CategoryMenu()
        {
            var categories = _db.Categories.ToList();

            return PartialView("_CategoryMenu",categories);
        }

        public ActionResult ProductTips(string term)
        {
            var product = _db.Products.Where(a => !a.Hidden && a.Name.ToLower().Contains(term.ToLower())).Take(5)
                .Select(a => new {label = a.Name});

            return Json(product, JsonRequestBehavior.AllowGet);
        }
    }
}