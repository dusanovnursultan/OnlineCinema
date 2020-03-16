using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineCinema
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(null,
                "{controller}/Session={page}",
                // eshop.ru/ExternalHDDs/page=4
                new
                {
                    controller = "Home",
                    action = "Session"
                },
                new { page = @"\d+" });
            /*
            routes.MapRoute(null,
                "{controller}/JsonOrder/{json}",
                // eshop.ru/ExternalHDDs/page=4
                new
                {
                    controller = "Sales",
                    action = "JsonOrder",
                    json = UrlParameter.Optional
                });*/
        }
    }
}
