﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
          routes.MapHttpRoute("Api Action", "api/{controller}/{action}/{id}", new {action="Get", id = RouteParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Startpage", id = UrlParameter.Optional }
            );
        //    routes.MapRoute(
        //"ErrorHandler",
        //"Error/{action}/{errMsg}",
        //new { controller = "Error", action = "Unauthorised", errMsg = UrlParameter.Optional }
        //);
        }
    }
}
