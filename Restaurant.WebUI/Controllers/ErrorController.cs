using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Error400()
        {
            Response.StatusCode = 400;
            return View("BadRequest");
        }

        public ActionResult Error404()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

        public ActionResult Error500()
        {
            Response.StatusCode = 500;
            return View("InternalServerError");
        }
    }
}