using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models;

namespace Lussans_Halen_V1.Controllers
{
    public class SpecialEventsController : Controller
    {
        private readonly ISpecialEventsService _specialEventsService; 

        public SpecialEventsController(ISpecialEventsService specialEventsService)
        {
            _specialEventsService = specialEventsService;
        }



        // GET: SpecialEventsController
        public ActionResult Index()
        {
            return View(_specialEventsService.All());
        }

        // GET: SpecialEventsController
        public ActionResult PrivateIndex()
        {
            return View(_specialEventsService.All());
        }



        // GET: SpecialEventsController/Create
        public ActionResult Create()
        {
            CreateSpecialEventsViewModel createSpecialEvent = new CreateSpecialEventsViewModel();
            return View(createSpecialEvent);
        }

        // POST: SpecialEventsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSpecialEventsViewModel createSpecialEvents)
        {
            try
            {
                if(ModelState.IsValid && createSpecialEvents != null)
                {
                    _specialEventsService.Add(createSpecialEvents);
                    return RedirectToAction("PrivateIndex");
                }

                return View(createSpecialEvents);

                
            }
            catch
            {
                return View(createSpecialEvents);
            }
        }

        // GET: SpecialEventsController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: SpecialEventsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateSpecialEventsViewModel editSpecialEvents)
        {
            try
            {
                SpecialEvent specialEvent = new SpecialEvent();
                if (id == 0 && editSpecialEvents.SpecialEventsId != 0)
                {
                    specialEvent = _specialEventsService.FindById(editSpecialEvents.SpecialEventsId);
                }
                else
                {
                    specialEvent = _specialEventsService.FindById(id);
                }


                CreateSpecialEventsViewModel newSpecialEvents = new CreateSpecialEventsViewModel();

                newSpecialEvents.SpecialEventsId = id;
                newSpecialEvents.SpecialEventsName = specialEvent.SpecialEventsInfoName;
                newSpecialEvents.SpecialEventsDiscription = specialEvent.SpecialEventsDiscription;

                if (ModelState.IsValid && editSpecialEvents.SpecialEventsId != 0)
                {
                    id = specialEvent.SpecialEventsId;
                    _specialEventsService.Edit(id, editSpecialEvents);
                    return RedirectToAction("PrivateIndex", "SpecialEvents");
                }
                return View(newSpecialEvents);
            }
            catch
            {
                return View();
            }
        }

        // GET: SpecialEventsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecialEventsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _specialEventsService.Remove(id);
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
