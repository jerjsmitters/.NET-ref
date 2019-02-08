using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cards
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Show sets, add set",
                url: "{controller}/{action}",
                defaults: new { controller = "Sets", action = "Index"}
            );

            routes.MapRoute(
               name: "Edit set, delete set, add card",
               url: "{controller}/{action}/{setid}",
               defaults: new { controller = "Sets", action = "Edit", setid = "1" }
           );

            routes.MapRoute(
               name: "Edit card, delete card",
               url: "{controller}/show/{setid}/{cardid}/{action}",
               defaults: new { controller = "Sets", action = "Edit", setid = "1" }
           );
        }
    }
}
