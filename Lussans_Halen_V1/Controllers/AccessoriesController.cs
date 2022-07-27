using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models;

namespace Lussans_Halen_V1.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IAccessoriesService _accessoriesService;

        public AccessoriesController(IAccessoriesService accessoriesService)
        {
            _accessoriesService = accessoriesService;
        }



        // GET: AccessoriesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccessoriesController
        public ActionResult PrivateIndex()
        {
            return View();
        }


        // GET: AccessoriesController/Create
        public ActionResult Create()
        {
            CreateAccessoriesViewModel createAccessories = new CreateAccessoriesViewModel();
            createAccessories.ListAccessories = _accessoriesService.All();

            return View(createAccessories);
        }

        // POST: AccessoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAccessoriesViewModel createAccessories)
        {
            try
            {
                if (ModelState.IsValid && createAccessories != null)
                {
                    _accessoriesService.Add(createAccessories);

                    return RedirectToAction("Create", "Dish");
                }


                return View(createAccessories);
            }
            catch
            {
                return View();
            }
        }

        // GET: AccessoriesController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: AccessoriesController/Edit/5
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

        // GET: AccessoriesController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: AccessoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {


                _accessoriesService.Remove(id);
               

                return RedirectToAction("Create", "Dish");
            }
            catch
            {
                return View();
            }
        }
    }
}
