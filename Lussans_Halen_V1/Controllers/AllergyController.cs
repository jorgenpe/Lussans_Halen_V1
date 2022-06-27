using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lussans_Halen_V1.Controllers
{
    public class AllergyController : Controller
    {
        // GET: AllergyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AllergyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AllergyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllergyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AllergyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AllergyController/Edit/5
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

        // GET: AllergyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AllergyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
