using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FASHIONWS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SPMRoute",
                url: "KFShop-SanPhamMoi/{name}-{id}",
                defaults: new { controller = "SanPham", action = "ThongTin" }
            );

            ////Bài tập 8.2
            //routes.MapRoute(
            //    name: "Map_Route_1",
            //    url: "{controller}/{action}/{name}-{id}"
            //    );

            //routes.MapRoute("MyRoute", "KFShop/{controller}/{action}/{id}",
            //        new { controller = "Home", action = "Index", id = UrlParameter.Optional });



            ////san pham moi
            //routes.MapRoute(
            //    name: "SPMRoute",
            //    url: "KFShop-SanPhamMoi/{action}/{name}-{id}",
            //    defaults: new { controller = "SanPham" }
            //);

            // Mặc định
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}