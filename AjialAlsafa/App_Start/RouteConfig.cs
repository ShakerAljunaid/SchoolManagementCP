using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AjialAlsafa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
         name: "ListAccounts",
         url: "Accounts/List/{typeId}",
         defaults: new { controller = "Accounts", action = "List", typeId = UrlParameter.Optional }
     );
            routes.MapRoute(
           name: "ListGeneralComponents",
           url: "GeneralComponents/List/{typeId}",
           defaults: new { controller = "GeneralComponents", action = "List", typeId = UrlParameter.Optional }
       );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
