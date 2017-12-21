using System.Web.Mvc;
using System.Web.Routing;

namespace Pharmacy_Online
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductDetail",
                url: "Product-{id}.html",
                defaults: new { controller = "Products", action = "Details" }
            );

            routes.MapRoute(

                name: "StaticPages",
                url: "Pages/{name}",
                defaults: new {controller = "Home", action = "StaticPages"}
            );

            routes.MapRoute(
                name: "Categories",
                url: "Category/{categoryname}",
                defaults: new {controller = "Products", action = "List"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
