using Microsoft.AspNet.Identity.Owin;
using Restaurant.Domain.Entities;
using Restaurant.WebUI.App_Start;
using Restaurant.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }

            private set
            {
                _roleManager = value;
            }
        }

        // GET: /Role/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "In forms is error, please correct your data.");
                return View();
            }
            var role = new ApplicationRole { Name = model.RoleName, AddedDate = DateTime.Now };
            var result = await RoleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                string msg = "New role is created. Role name: " + role.Name + ".";
                TempData["Message"] = msg;
                return RedirectToAction("Index", "Admin");
            }
            ModelState.AddModelError("", "Role in not added. Try again.");
            return View();
        }

        // GET: /Role/List
        public ActionResult List()
        {
            List<RoleListViewModel> model = RoleManager.Roles.Select(s => new RoleListViewModel
            {
                AddedDate = s.AddedDate,
                Id = s.Id,
                RoleName = s.Name
            }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData["Message"] = "Role doesn't exist.";
                return RedirectToAction("List", "Role");
            }
            var result = await RoleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["Message"] = "Role is removed.";
                return RedirectToAction("Index", "Admin");
            }
            TempData["Message"] = "Role doesn't exist.";
            return RedirectToAction("List", "Role");
        }

        public ActionResult AmountOfRoles()
        {
            var amountOfRoles = RoleManager.Roles.Count();
            return Content(amountOfRoles.ToString());
        }

        public ActionResult DateLastAddedRole()
        {
            var date = RoleManager.Roles.Where(w => w.AddedDate < DateTime.Now).First().AddedDate;
            return Content(date.ToString());
        }

        public ActionResult RoleNameLastAddedRole()
        {
            var roleName = RoleManager.Roles.Where(w => w.AddedDate < DateTime.Now).First().Name;
            return Content(roleName);
        }
    }
}