using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using Restaurant.WebUI.Infrastructure.Managers;
using Restaurant.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    [Authorize(Roles ="Employee")]
    public class DishController : Controller
    {
        readonly IEFDishRepository _repository;
        readonly IEFMenuCategoryRepository _menuCatRep;
        readonly int maxPosition = 100;

        public DishController(IEFDishRepository repository, IEFMenuCategoryRepository menuCatRep)
        {
            _repository = repository;
            _menuCatRep = menuCatRep;
        }

        // GET: Dish/Index
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult DishListPartial(string menuCategoryName)
        {
            ViewBag.MenuCategory = menuCategoryName;
            var model = _repository.GetDishesByMenuCategoryOrderByPositionAsc(menuCategoryName);
            return PartialView("_DishListPartial", model);
        }

        [HttpGet]
        public ActionResult DishListForManagePartial(string menuCategoryName)
        {
            ViewBag.MenuCategory = menuCategoryName;
            var model = _repository.GetDishesByMenuCategoryOrderByPositionAsc(menuCategoryName);
            return PartialView("_DishListForManagePartial", model);
        }

        // GET: MenuCategory/Manage
        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }

        // GET: Dish/Create
        [HttpGet]
        public ActionResult Create()
        {
            var menuCategoryNames = _menuCatRep.GetCategoryNames();
            CreateDishViewModel model = new CreateDishViewModel()
            {
                MenuCategories = new SelectList(menuCategoryNames),
                Positions = new SelectList(GetPositionList())
            };
            return View(model);
        }

        // POST: Dish/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Positions,MenuCategories")]CreateDishViewModel model,
                                   HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "In forms is error, please correct your data.");
                return View();
            }
            var menuCategory = _menuCatRep.GetByName(model.MenuCategoryName);
            Dish dish = new Dish()
            {
                Description = model.Description,
                Name = model.Name,
                Position = model.Position,
                Price = model.Price,
                MenuCatId = menuCategory.Id
            };
            if (photo != null)
            {
                dish.Photo = PhotoManager.GetBytes(photo);
                dish.PhotoMimeType = photo.ContentType;
            }
            _repository.Add(dish);
            _repository.Save();
            TempData["Message"] = "New dish:" + dish.Name + " has been added.";
            return RedirectToAction("Manage", "Dish");
        }

        // GET: Dish/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var dish = _repository.GetById(id);
            if (dish == null) return HttpNotFound();
            _repository.Delete(dish);
            _repository.Save();
            TempData["Message"] = "The dish: " + dish.Name + " has been deleted.";
            return RedirectToAction("Manage", "Dish");
        }

        // GET: Dish/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var menuCategoryNames = _menuCatRep.GetCategoryNames();
            var dish = _repository.GetById(id);
            if (dish == null) return HttpNotFound();
            var positions = GetPositionList();
            positions.Add(dish.Position);
            positions.Sort();
            EditDishViewModel model = new EditDishViewModel()
            {
                DishID = dish.Id,
                Description = dish.Description,
                Name = dish.Name,
                Price = dish.Price,
                Position = dish.Position,
                MenuCategoryName = dish.MenuCategory.Name,
                MenuCategories = new SelectList(menuCategoryNames),
                Positions = new SelectList(positions),
                Photo = dish.Photo,
                PhotoMimeType = dish.PhotoMimeType
            };
            return View(model);
        }

        // POST: Dish/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Positions,MenuCategories")]EditDishViewModel model,
                                 HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                var menuCategory = _menuCatRep.GetByName(model.MenuCategoryName);
                Dish dish = new Dish
                {
                    Id = model.DishID,
                    Description = model.Description,
                    Name = model.Name,
                    Price = model.Price,
                    Position = model.Position,
                    MenuCatId = menuCategory.Id
                };
                if (photo != null)
                {
                    dish.Photo = PhotoManager.GetBytes(photo);
                    dish.PhotoMimeType = photo.ContentType;
                }
                else
                {
                    dish.PhotoMimeType = model.PhotoMimeType;
                    dish.Photo = model.Photo;
                }
                _repository.Update(dish);
                _repository.Save();
                TempData["Message"] = "The dish: " + model.Name + " has been changed.";
                return RedirectToAction("Manage", "Dish");
            }
            ModelState.AddModelError("", "Model is not valid.");
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetPhoto(int? id)
        {
            var dish = _repository.GetById(id);
            if (dish != null)
                if (dish.Photo != null)
                    return File(dish.Photo, dish.PhotoMimeType);
            return null;
        }

        public List<int> GetPositionList()
        {
            var list = new List<int>();
            for (int i = 0; i < maxPosition; ++i)
                list.Add(i + 1);
            var assignedPositions = _repository.GetAssignedPositions();
            list = list.Except(assignedPositions).ToList<int>();
            return list;
        }
    }
}