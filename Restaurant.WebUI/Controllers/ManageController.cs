using Restaurant.Domain.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        readonly IEFDishRepository _dishRep;
        readonly IEFMenuCategoryRepository _menuCatRep;
        readonly IEFReservationRepository _reservRep;
        readonly IEFGalleryRepository _galleryRep;

        public ManageController(IEFDishRepository dishRep, IEFMenuCategoryRepository menuCatRep,
                                IEFReservationRepository reservRep, IEFGalleryRepository galleryRep)
        {
            _dishRep = dishRep;
            _menuCatRep = menuCatRep;
            _reservRep = reservRep;
            _galleryRep = galleryRep;
        }

        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAmountOfReservations()
        {
            var amount = _reservRep.AmountOfElements();
            return Content(amount.ToString());
        }

        public ActionResult GetAmountOfDishes()
        {
            var amount = _dishRep.AmountOfElements();
            return Content(amount.ToString());
        }

        public ActionResult GetAmountOfMenuCategories()
        {
            var amount = _menuCatRep.AmountOfElements();
            return Content(amount.ToString());
        }

        public ActionResult GetAmountOfGalleryPictures()
        {
            var amount = _galleryRep.AmountOfElements();
            return Content(amount.ToString());
        }
    }
}