using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Helpers
{
    public static class NavHelper
    {
        public static string IsSelected(this HtmlHelper html, string action, string controller, string className)
        {
            var routeData = html.ViewContext.RouteData.Values;
            var actionName = routeData["action"] as string;
            var controllerName = routeData["controller"] as string;
            if (action.Equals(actionName) && controller.Equals(controllerName))
                return className;
            return null;
        }
    }
}