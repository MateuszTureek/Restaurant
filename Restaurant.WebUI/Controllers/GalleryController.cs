using Restaurant.Domain.Abstract.Repository;
using Restaurant.Domain.Entities;
using Restaurant.WebUI.Infrastructure.Managers;
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
    public class GalleryController : Controller
    {
        IEFGalleryRepository _repository;

        public GalleryController(IEFGalleryRepository repository)
        {
            _repository = repository;
        }

        // GET: Gallery/Index
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = _repository.GetGalleryByPosition();
            return View(model);
        }

        // GET: Gallery/Manage
        [HttpGet]
        public ActionResult Manage()
        {
            var model = _repository.GetGalleryByPosition();
            return View(model);
        }

        // GET: Gallery/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateGalleryItemViewModel());
        }

        //POST: Gallery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGalleryItemViewModel model, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "In forms is error, please correct your data.");
                return View();
            }
            if (image == null)
            {
                ModelState.AddModelError("", "Image isn't sended");
                return View();
            }
            if (image.ContentLength == 0)
            {
                ModelState.AddModelError("", "Image isn't sended");
                return View();
            }
            var galleryItem = new Gallery
            {
                Position = model.Position,
                Image = PhotoManager.GetBytes(image),
                ImageMimeType = image.ContentType
            };
            _repository.Add(galleryItem);
            _repository.Save();
            TempData["Message"] = "The gallery item has been added.";
            return RedirectToAction("Manage", "Gallery");
        }

        //POST: Gallery/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var galleryItem = _repository.GetById(id);
            if (galleryItem == null) return HttpNotFound();
            _repository.Delete(galleryItem);
            _repository.Save();
            TempData["Message"] = "The gallery item has been deleted.";
            return RedirectToAction("Manage", "Gallery");
        }

        //GET: Gallery/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var galleryItem = _repository.GetById(id);
            if (galleryItem == null) return HttpNotFound();
            var model = new EditGalleryItemViewModel
            {
                Id = galleryItem.Id,
                Position = galleryItem.Position,
                Image = galleryItem.Image,
                ImageMimeType = galleryItem.ImageMimeType
            };
            return View(model);
        }

        //POST: Gallery/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditGalleryItemViewModel model, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "In forms is error, please correct your data.");
                return View();
            }
            var galleryItem = new Gallery
            {
                Id = model.Id,
                Position = model.Position
            };
            if (image != null)
            {
                galleryItem.Image = PhotoManager.GetBytes(image);
                galleryItem.ImageMimeType = image.ContentType;
            }
            else
            {
                galleryItem.Image = model.Image;
                galleryItem.ImageMimeType = model.ImageMimeType;
            }
            _repository.Update(galleryItem);
            _repository.Save();
            TempData["Message"] = "The gallery item has been changed.";
            return RedirectToAction("Manage", "Gallery");
        }

        [AllowAnonymous]
        public ActionResult GetImage(int? id)
        {
            var galleryItem = _repository.GetById(id);
            if (galleryItem != null)
                if (galleryItem.Image != null)
                    return File(galleryItem.Image, galleryItem.ImageMimeType);
            return null;
        }
    }
}