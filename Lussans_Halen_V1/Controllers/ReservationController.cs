using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models;
namespace Lussans_Halen_V1.Controllers
{
    public class ReservationController : Controller
    {

        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            return View(_reservationService.All());
        }

        public ActionResult PrivateIndex()
        {
            return View(_reservationService.All());
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            CreateReservationViewModel createReservation = new CreateReservationViewModel();    
            return View(createReservation);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReservationViewModel createReservation)
        {
            try
            {
                if(ModelState.IsValid && createReservation != null)
                {
                    _reservationService.Add(createReservation);

                    return RedirectToAction("PrivateIndex");
                }
                return View(createReservation);
            }
            catch
            {
                return View(createReservation);
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit()
        {
            //CreateReservationViewModel editReservation = new CreateReservationViewModel();
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateReservationViewModel editReservation)
        {
            try
            {
                Reservation reservation = new Reservation();
                if (id == 0 && editReservation.ReservationId != 0) 
                {
                    reservation = _reservationService.FindById(editReservation.ReservationId);
                } else
                {
                    reservation = _reservationService.FindById(id);
                }
                
                CreateReservationViewModel newReservation = new CreateReservationViewModel();

                newReservation.ReservationId = id;
                newReservation.ReservationName = reservation.ReservationName;
                newReservation.ReservationDescription = reservation.ReservationDescription;

                if(ModelState.IsValid && editReservation.ReservationId != 0)
                {
                    id = reservation.ReservationId;
                    _reservationService.Edit(id, editReservation);
                    return RedirectToAction("PrivateIndex");
                }
                return View(newReservation);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _reservationService.Remove(id);
                }
                return RedirectToAction("PrivateIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
