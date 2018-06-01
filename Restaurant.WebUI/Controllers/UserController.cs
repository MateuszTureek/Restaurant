using Microsoft.AspNet.Identity.EntityFramework;
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
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private string employeeRoleName = "Employee";

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                _userManager = value;
            }
        }

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

        // GET: /User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Post: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "In forms is error, please correct your data.");
                return View();
            }
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, AccountRegisterDate = DateTime.Now };
            var result = await UserManager.CreateAsync(user, model.Password);
            await UserManager.AddToRoleAsync(user.Id, employeeRoleName);
            if (result.Succeeded)
            {
                string msg = "User account is created. User name: " + user.UserName + ".";
                TempData["Message"] = msg;
                return RedirectToAction("Index", "Admin");
            }
            ModelState.AddModelError("", "User account is not created. Try again.");
            return View();
        }

        // GET: /User/List
        [HttpGet]
        public async Task<ActionResult> List()
        {
            var employeeRole = await RoleManager.FindByNameAsync(employeeRoleName);
            var userRoles = employeeRole.Users.ToList();
            var users = UserManager.Users.ToList();
            List<UserListViewModel> model = users.Join(userRoles, u => u.Id, r => r.UserId, (u, r) => new { u, r }).
                Select(s => new UserListViewModel
                {
                    AddedDate = s.u.AccountRegisterDate,
                    Email = s.u.Email,
                    PhonNumber = s.u.PhoneNumber,
                    UserName = s.u.UserName,
                    UserID = s.u.Id
                }).ToList();
            return View(model);
        }

        // POST: /User/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            string msg;
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                msg = "User doesn't exist.";
                TempData["Message"] = msg;
                return RedirectToAction("List", "User");
            }
            var result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                msg = "User: " + user.UserName + " is removed.";
                TempData["Message"] = msg;
                return RedirectToAction("Index", "Admin");
            }
            msg = "Account is not removed, try again.";
            TempData["Message"] = msg;
            return RedirectToAction("List", "User");
        }

        public ActionResult AmountOfUsers()
        {
            var employeeRole = RoleManager.FindByNameAsync(employeeRoleName);
            var amountOfUsers = employeeRole.Result.Users.Count;
            return Content(amountOfUsers.ToString());
        }

        public ActionResult DateLastAddedUser()
        {
            var date = UserManager.Users.Where(w => w.AccountRegisterDate < DateTime.Now).First().AccountRegisterDate;
            return Content(date.ToString());
        }

        public ActionResult UsernameLastAddedUser()
        {
            var userName = UserManager.Users.Where(w => w.AccountRegisterDate < DateTime.Now).First().UserName;
            return Content(userName);
        }
    }
}