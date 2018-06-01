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
    [Authorize(Roles = "Employee")]
    public class ReservationController : Controller
    {
        IEFReservationRepository _repository;

        public ReservationController(IEFReservationRepository repository)
        {
            _repository = repository;
        }

        // GET: Reservation/Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reservation/Create
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListNumerOfQuests = new List<SelectListItem>()
            {
                new SelectListItem() { Text="1", Value="1" },
                new SelectListItem() { Text="2", Value="2" },
                new SelectListItem() { Text="4", Value="4" }
            };
            return View(new ReservationViewModel());
        }

        // POST: Reservation/Create
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "In forms is error, please correct your data.");
                return View();
            }
            Reservation reservation = new Reservation()
            {
                Email = model.Email,
                Name = model.Name,
                NumberOfGuests = model.NumberOfGuests,
                PhoneNumber = model.PhoneNumber,
                Term = model.Term
            };
            _repository.Add(reservation);
            _repository.Save();
            return PartialView("ReservationResult");
        }

        [HttpPost]
        public ActionResult ConfirmArrived(int? id)
        {
            if (id == null) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var reservation = _repository.GetById(id);
            if (reservation == null) return HttpNotFound();
            reservation.Arrived = true;
            _repository.Update(reservation);
            _repository.Save();
            return Json(HttpStatusCode.OK);
        }

        [ChildActionOnly]
        public ActionResult TodayReservations()
        {
            var nowDateTime = DateTime.Now;
            var startDateTime = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day,
                                           6, 00, 00);
            var endDateTime = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day,
                                           23, 59, 59);
            var reservations = _repository.GetByTerm(startDateTime, endDateTime);
            return PartialView("TodayReservationList", reservations);
        }

        public ActionResult Reservations()
        {
            var nowDateTime = DateTime.Now;
            var startDateTime = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day,
                                           00, 00, 00);
            var endDateTime = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day,
                                           23, 59, 59);
            endDateTime = endDateTime.AddYears(1);
            var reservations = _repository.GetByTerm(startDateTime, endDateTime);
            return PartialView("ReservationList", reservations);
        }

        public ActionResult HistoryReservations()
        {
            var nowDateTime = DateTime.Now;
            var startDateTime = new DateTime(nowDateTime.Year, nowDateTime.Month, nowDateTime.Day, 0, 0, 0);
            startDateTime = startDateTime.AddYears(-1);
            var endDateTime = nowDateTime;
            endDateTime = endDateTime.AddDays(-1);
            var reservations = _repository.GetByTerm(startDateTime, endDateTime);
            return PartialView("ReservationList", reservations);
        }
    }
}