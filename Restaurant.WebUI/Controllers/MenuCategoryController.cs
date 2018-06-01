using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using Restaurant.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    [Authorize(Roles ="Employee")]
    public class MenuCategoryController : Controller
    {
        readonly IEFMenuCategoryRepository _repository;

        public MenuCategoryController(IEFMenuCategoryRepository repository)
        {
            _repository = repository;
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult MenuCategoryList()
        {
            var model = _repository.GetByPosition();
            return PartialView("_MenuCategoryListPartial", model);
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult MenuCategoryForManageList()
        {
            var model = _repository.GetByPosition();
            return PartialView("_MenuCategoryListForManagePartial", model);
        }

        // GET: MenuCategory/Manage
        [HttpGet]
        public ActionResult Manage()
        {
            var model = _repository.GetByPosition();
            return View(model);
        }

        // GET: MenuCategory/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new MenuCategoryViewModel());
        }

        // POST: MenuCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "In forms is error, please correct your data.");
                return View();
            }
            var menuCategory = new MenuCategory()
            {
                Name = model.Name,
                Position = model.Position
            };
            _repository.Add(menuCategory);
            _repository.Save();
            TempData["Message"] = "The menu category: " + menuCategory.Name + " has been added.";
            return RedirectToAction("Manage", "MenuCategory");
        }

        // POST: MenuCategory/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var menuCategory = _repository.GetById(id);
            if (menuCategory == null) return HttpNotFound();
            _repository.Delete(menuCategory);
            _repository.Save();
            TempData["Message"] = "The menu category: " + menuCategory.Name + " has been deleted.";
            return RedirectToAction("Manage", "MenuCategory");
        }

        // GET: MenuCategory/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var menuCategory = _repository.GetById(id);
            if (menuCategory == null) return HttpNotFound();
            MenuCategoryViewModel model = new MenuCategoryViewModel
            {
                Id = menuCategory.Id,
                Name = menuCategory.Name,
                Position = menuCategory.Position
            };
            return View(model);
        }

        // POST: MenuCategory/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model is not valid.");
                return View();
            }
            var menuCategory = new MenuCategory
            {
                Id = model.Id,
                Name = model.Name,
                Position = model.Position
            };
            _repository.Update(menuCategory);
            _repository.Save();
            TempData["Message"] = "The menu category: " + model.Name + " has been changed.";
            return RedirectToAction("Manage", "MenuCategory");
        }
    }
}