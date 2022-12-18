using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;


namespace Lussans_Halen_V1.Controllers
{
    
    public class OpenTimesController : Controller
    {
        
        private readonly IOpenTimesService _openTimesService;

        public OpenTimesController(IOpenTimesService openTimesService)
        {
            _openTimesService = openTimesService;
        }

        // GET: OpenTimesController
        public ActionResult Index()
        {
            return View(_openTimesService.All());
        }

        // GET: OpenTimesController
        public ActionResult PrivateIndex()
        {
            return View(_openTimesService.All());
        }

        // GET: OpenTimesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OpenTimesController/Create
        public ActionResult Create()
        {

            CreateOpenTimesViewModel openTimes = new CreateOpenTimesViewModel();
            return View(openTimes);
        }

        // POST: OpenTimesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateOpenTimesViewModel createOpenTimes)
        {
            try
            {
                if (ModelState.IsValid && createOpenTimes != null)
                {
                    _openTimesService.Add(createOpenTimes);

                    return RedirectToAction("PrivateIndex");
                }

                return View(createOpenTimes);
            }
            catch
            {
                return View();
            }
        }

        // GET: OpenTimesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OpenTimesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OpenTimesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OpenTimesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _openTimesService.Remove(id);
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
