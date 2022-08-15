using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models;
using System;
using System.Linq;
using System.Globalization;

namespace Lussans_Halen_V1.Controllers
{
    public class WeekMenuController : Controller
    {

        private readonly IDishService _dishService;
        private readonly IDishWeekMenuService _dishWeekMenuService;
        private readonly IWeekMenuService _weekMenuService;
        




        public WeekMenuController(IDishService dishService, IDishWeekMenuService dishWeekMenuService, IWeekMenuService weekMenuService)
        {
            _dishService = dishService;
            _dishWeekMenuService = dishWeekMenuService;
            _weekMenuService = weekMenuService;
        }



        // GET: WeekMenuController
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            int currentWeek = ISOWeek.GetWeekOfYear(date);
            CreateWeekMenuViewModel weekMenu = new CreateWeekMenuViewModel();

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.WeekNumber == currentWeek)
                {
                    weekMenu.DayPrice = menuWeek.DayPrice;
                    
                    break;
                }
            }

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.DayAccessories != null)
                {
                    
                    weekMenu.DayAccessories = menuWeek.DayAccessories;
                    break;
                }
            }
            weekMenu.Weeks = WeekInYear();
            weekMenu.Week = currentWeek;
            weekMenu.DishList = _dishService.All();
            weekMenu.DishWeekMenuList = _dishWeekMenuService.All();
            weekMenu.WeekMenuList = _weekMenuService.All();
            return View(weekMenu);
        }

        [HttpPost]
        public ActionResult Index(int weekNumber)
        {
            DateTime date = DateTime.Now;
            int currentWeek = weekNumber;

            CreateWeekMenuViewModel weekMenu = new CreateWeekMenuViewModel();

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.WeekNumber == currentWeek)
                {
                    weekMenu.DayPrice = menuWeek.DayPrice;
                    
                    break;
                }
            }

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.DayAccessories != null)
                {

                    weekMenu.DayAccessories = menuWeek.DayAccessories;
                    break;
                }
            }

            weekMenu.Weeks = WeekInYear();
            weekMenu.Week = currentWeek;
            weekMenu.DishList = _dishService.All();
            weekMenu.DishWeekMenuList = _dishWeekMenuService.All();
            weekMenu.WeekMenuList = _weekMenuService.All();



            return View(weekMenu);
        }

        // GET: WeekMenuController
        public ActionResult PrivateIndex()
        {
            DateTime date = DateTime.Now;
            int currentWeek = ISOWeek.GetWeekOfYear(date);
            CreateWeekMenuViewModel weekMenu = new CreateWeekMenuViewModel();

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.WeekNumber == currentWeek)
                {
                    weekMenu.DayPrice = menuWeek.DayPrice;

                    break;
                }
            }

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.DayAccessories != null)
                {

                    weekMenu.DayAccessories = menuWeek.DayAccessories;
                    break;
                }
            }
            weekMenu.Weeks = WeekInYear();
            weekMenu.Week = currentWeek;
            weekMenu.DishList = _dishService.All();
            weekMenu.DishWeekMenuList = _dishWeekMenuService.All();
            weekMenu.WeekMenuList = _weekMenuService.All();
            return View(weekMenu);
        }

        [HttpPost]
        public ActionResult PrivateIndex(int weekNumber)
        {
            DateTime date = DateTime.Now;
            int currentWeek = weekNumber;
            
            CreateWeekMenuViewModel weekMenu = new CreateWeekMenuViewModel();

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.WeekNumber == currentWeek)
                {
                    weekMenu.DayPrice = menuWeek.DayPrice;

                    break;
                }
            }

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.DayAccessories != null)
                {

                    weekMenu.DayAccessories = menuWeek.DayAccessories;
                    break;
                }
            }
            weekMenu.Weeks = WeekInYear();
            weekMenu.Week = currentWeek;
            weekMenu.DishList = _dishService.All();
            weekMenu.DishWeekMenuList = _dishWeekMenuService.All();
            weekMenu.WeekMenuList = _weekMenuService.All();

            

            return View(weekMenu);
        }

        // GET: WeekMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeekMenuController/Create
        public ActionResult Create()
        {
            DateTime date = DateTime.Now;
            int currentWeek = ISOWeek.GetWeekOfYear(date);
            CreateWeekMenuViewModel weekMenu = new CreateWeekMenuViewModel();

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.WeekNumber == currentWeek)
                {
                    weekMenu.DayPrice = menuWeek.DayPrice;

                    break;
                }
            }

            foreach (WeekMenu menuWeek in _weekMenuService.All())
            {
                if (menuWeek.DayAccessories != null)
                {

                    weekMenu.DayAccessories = menuWeek.DayAccessories;
                    break;
                }
            }
            weekMenu.Weeks = WeekInYear();
            weekMenu.Week = currentWeek;
            weekMenu.DishList = _dishService.All();
            weekMenu.DishWeekMenuList = _dishWeekMenuService.All();
            weekMenu.WeekMenuList = _weekMenuService.All();
            return View(weekMenu);
        }

        // POST: WeekMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateWeekMenuViewModel createWeekMenu)
        {
            try
            {

                if(ModelState.IsValid && createWeekMenu != null)
                {
                    
                    WeekMenu temp = _weekMenuService.Add(createWeekMenu);
                    
                    foreach(int dishId in createWeekMenu.ListDishId)
                    {

                        foreach(DishWeekMenu dishWeek in _dishWeekMenuService.All())
                        {
                            
                            if (dishWeek.DishId == dishId && _weekMenuService.FindById(dishWeek.WeekMenuId).Day == temp.Day && _weekMenuService.FindById(dishWeek.WeekMenuId).WeekNumber == temp.WeekNumber)
                            {
                                _weekMenuService.Remove(temp.WeekMenuId);
                                return RedirectToAction("PrivateIndex");
                            }
                        }
                        CreateDishsWeeksMenuViewModel weekMenuDish = new CreateDishsWeeksMenuViewModel();

                        weekMenuDish.DishId = dishId;
                        weekMenuDish.WeekMenuId = temp.WeekMenuId;
                        _dishWeekMenuService.Add(weekMenuDish);
                    }
                    foreach (WeekMenu weekMenu in _weekMenuService.All())
                    {
                        if (weekMenu.WeekNumber == temp.WeekNumber)
                        {

                            CreateWeekMenuViewModel weekMenuViewModel = new CreateWeekMenuViewModel();
                            weekMenuViewModel.WeekNumber = weekMenu.WeekNumber;
                            weekMenuViewModel.WeekMenuId = weekMenu.WeekMenuId;
                            weekMenuViewModel.Day = weekMenu.Day;
                            weekMenuViewModel.DayPrice = temp.DayPrice;
                            weekMenuViewModel.DayAccessories = temp.DayAccessories;
                            


                            _weekMenuService.Edit(weekMenu.WeekMenuId, weekMenuViewModel);
                        }
                    }
                    foreach (WeekMenu weekMenu in _weekMenuService.All())
                    {
                        

                            CreateWeekMenuViewModel weekMenuViewModel = new CreateWeekMenuViewModel();
                            weekMenuViewModel.WeekNumber = weekMenu.WeekNumber;
                            weekMenuViewModel.WeekMenuId = weekMenu.WeekMenuId;
                            weekMenuViewModel.Day = weekMenu.Day;
                            weekMenuViewModel.DayPrice = weekMenu.DayPrice;
                            weekMenuViewModel.DayAccessories = temp.DayAccessories;



                            _weekMenuService.Edit(weekMenu.WeekMenuId, weekMenuViewModel);
                        
                    }
                    return RedirectToAction("PrivateIndex");
                }


                return View(createWeekMenu);
            }
            catch
            {
                return View();
            }
        }

        // GET: WeekMenuController/Edit/5
        public ActionResult Edit(int id)
        {

            CreateWeekMenuViewModel editWeekMenu = new CreateWeekMenuViewModel();
            editWeekMenu.DishList = _dishService.All();
            editWeekMenu.Weeks = WeekInYear();
            return View(editWeekMenu);
        }

        // POST: WeekMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateWeekMenuViewModel editWeekMenu)
        {
            try
            {
                List<int> listDishs = new List<int>();

                foreach (DishWeekMenu dishWeekMenu in _dishWeekMenuService.All())
                {
                    if(dishWeekMenu.DishId == id)
                    {
                        listDishs.Add(dishWeekMenu.DishId);
                    }
                }

                WeekMenu weekMenu = new WeekMenu();

                if(id ==0 && editWeekMenu.WeekMenuId != 0)
                {
                    weekMenu = _weekMenuService.FindById(editWeekMenu.WeekMenuId);
                }
                else
                {
                    weekMenu = _weekMenuService.FindById(id);
                }

                CreateWeekMenuViewModel newEditWeekMenu = new CreateWeekMenuViewModel();

                newEditWeekMenu.WeekMenuId = id;
                newEditWeekMenu.WeekNumber = weekMenu.WeekNumber;
                newEditWeekMenu.Day = weekMenu.Day;
                newEditWeekMenu.DayPrice = weekMenu.DayPrice;
                newEditWeekMenu.DishList = _dishService.All();
                newEditWeekMenu.ListDishId = listDishs;
                newEditWeekMenu.DayAccessories = weekMenu.DayAccessories;

                if(ModelState.IsValid && editWeekMenu != null)
                {

                    foreach(int DishId in listDishs)
                    {
                        CreateDishsWeeksMenuViewModel dishsWeeksMenuRemove = new CreateDishsWeeksMenuViewModel();
                        dishsWeeksMenuRemove.WeekMenuId = id;
                        dishsWeeksMenuRemove.DishId = DishId;
                        _dishWeekMenuService.Remove(dishsWeeksMenuRemove);
                    }


                    foreach (int DishId in editWeekMenu.ListDishId)
                    {
                        CreateDishsWeeksMenuViewModel dishsWeeksMenu = new CreateDishsWeeksMenuViewModel();
                        dishsWeeksMenu.WeekMenuId = id;
                        dishsWeeksMenu.DishId = DishId;
                        _dishWeekMenuService.Add(dishsWeeksMenu);
                    }

                    editWeekMenu.ListDishId = listDishs;
                    editWeekMenu.DishList = _dishService.All();
                    _weekMenuService.Edit(id, editWeekMenu);

                    return RedirectToAction("privateIndex");
                }

                return View(newEditWeekMenu);
               
            }
            catch
            {
                return View();
            }
        }

        // GET: WeekMenuController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: WeekMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _weekMenuService.Remove(id);
                }
                return RedirectToAction("PrivateIndex");
            }
            catch
            {
                return View();
            }
        }

        private List<int> WeekInYear()
        {
            List<int> listWeeksInYear = new List<int>();

            for (int i = 0; i < ISOWeek.GetWeeksInYear(DateTime.Now.Year); i++)
            {
                listWeeksInYear.Add(i+1);
            }

            return listWeeksInYear;
        }
    }
}
