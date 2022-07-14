using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models;

namespace Lussans_Halen_V1.Controllers
{
    public class AllergyController : Controller
    {
        private readonly IAllergyService _allergyService;

        public AllergyController(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }



        // GET: AllergyController
        public ActionResult Index()
        {
            return View(_allergyService.All());
        }

        public ActionResult PrivateIndex()
        {
            return View(_allergyService.All());
        }

        
        // GET: AllergyController/Create
        public ActionResult Create()
        {
            CreateAllergyViewModel createAllergy = new CreateAllergyViewModel();
            return View(createAllergy);
        }

        // POST: AllergyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAllergyViewModel createAllergy)
        {
            try
            {
                if(ModelState.IsValid && createAllergy != null)
                {
                    _allergyService.Add(createAllergy);

                    return RedirectToAction("PrivateIndex");
                }


                return View(createAllergy);
            }
            catch
            {
                return View();
            }
        }

        // GET: AllergyController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: AllergyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateAllergyViewModel editAllergy)
        {
            try
            {
                Allergy allergy = new Allergy();
                if(id == 0 && editAllergy.AllergyId != 0)
                {
                    allergy = _allergyService.FindById(editAllergy.AllergyId);
                }
                else
                {
                    allergy = _allergyService.FindById(id);
                }

                CreateAllergyViewModel newAllergy = new CreateAllergyViewModel();
                
                newAllergy.AllergyId = id;
                newAllergy.AllergyInfoName = allergy.AllergyInfoName;
                newAllergy.AllergyInfo = allergy.AllergyInfo;

                if (ModelState.IsValid && editAllergy.AllergyId != 0)
                {
                    id = allergy.AllergyId;
                    _allergyService.Edit(id,editAllergy);
                    return RedirectToAction("PrivateIndex");
                }

                return View(newAllergy);

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
                if (ModelState.IsValid)
                {
                    _allergyService.Remove(id);
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
