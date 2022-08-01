using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models;
using System;
using System.Linq;


namespace Lussans_Halen_V1.Controllers
{
    public class WeekMenuController : Controller
    {

        private readonly IDishService _dishService;
        private readonly IDishWeekMenuService _dishWeekMenuService;
        private readonly IWeekMenuService _WeekMenuService;

        public WeekMenuController(IDishService dishService, IDishWeekMenuService dishWeekMenuService, IWeekMenuService weekMenuService)
        {
            _dishService = dishService;
            _dishWeekMenuService = dishWeekMenuService;
            _WeekMenuService = weekMenuService;
        }



        // GET: WeekMenuController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WeekMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeekMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeekMenuController/Create
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

        // GET: WeekMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeekMenuController/Edit/5
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

        // GET: WeekMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeekMenuController/Delete/5
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
