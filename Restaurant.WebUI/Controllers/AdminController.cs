using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Restaurant.WebUI.App_Start;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using System.Linq;
using System;

namespace Restaurant.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}