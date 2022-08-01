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
    

    public class DishController : Controller
    {

        private readonly IDishService _dishService;
        private readonly IDishsAccessoriesService _dishsAccessoriesService;
        private readonly IAccessoriesService _accessoriesService;
    
        public DishController(IDishService dishService, IDishsAccessoriesService dishsAccessoriesService, IAccessoriesService accessoriesService)
        {
            _dishService = dishService;
            _dishsAccessoriesService = dishsAccessoriesService;
            _accessoriesService = accessoriesService;
        }
            
        // GET: DishController
        public ActionResult Index()
        {
            CreateDishViewModel dish = new CreateDishViewModel();




            dish.DishList = _dishService.All();
            dish.AccessoriesList = _accessoriesService.All();
            dish.DishAccessories = _dishsAccessoriesService.All();
            return View(dish);
        }


        // GET: DishController
        public ActionResult CatringIndex()
        {
            CreateDishViewModel dish = new CreateDishViewModel();




            dish.DishList = _dishService.All();
            dish.AccessoriesList = _accessoriesService.All();
            dish.DishAccessories = _dishsAccessoriesService.All();
            return View(dish);
        }
        // GET: DishController
        public ActionResult PrivateIndex()
        {
            CreateDishViewModel dish = new CreateDishViewModel();




            dish.DishList = _dishService.All();
            dish.AccessoriesList = _accessoriesService.All();
            dish.DishAccessories = _dishsAccessoriesService.All();
            return View(dish);
        }


        // GET: DishController/Create
        public ActionResult Create()
        {

            CreateDishViewModel createDishViewModel = new CreateDishViewModel();

            createDishViewModel.AccessoriesList = _accessoriesService.All();
            return View(createDishViewModel);
        }

        // POST: DishController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateDishViewModel createDish)
        {
            try
            {
                if (ModelState.IsValid && createDish != null)
                {
                    Dish temp = _dishService.Add(createDish);

                    foreach(int AccessoryId in createDish.ListAccessoriesId)
                    {
                        
                        CreateDishsAccessoriesViewModel dishAccessory = new CreateDishsAccessoriesViewModel();
                        dishAccessory.AccessoryId = AccessoryId;
                        dishAccessory.DishId = temp.DishId;
                        _dishsAccessoriesService.Add(dishAccessory);
                        
                    } 

                    return RedirectToAction("PrivateIndex");
                }
                return View(createDish);
            }
            catch
            {
                return View();
            }
        }

        // GET: DishController/Edit/5
        public ActionResult Edit()
        {
            CreateDishViewModel editDish = new CreateDishViewModel();

            editDish.AccessoriesList = _accessoriesService.All();
            



            return View(editDish);
        }

        // POST: DishController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateDishViewModel editDish)
        {
            try
            {
                List<int> listAccessories = new List<int>();

                foreach (DishAccessory dishAccessory in _dishsAccessoriesService.All())
                {
                    if (dishAccessory.DishId == id)
                    {
                        listAccessories.Add(dishAccessory.AccessoryId);
                    }
                }

                Dish dish= new Dish();
                if (id == 0 && editDish.DishId != 0)
                {
                    dish = _dishService.FindById(editDish.DishId);
                }
                else
                {
                    dish = _dishService.FindById(id);
                }

                CreateDishViewModel newDish = new CreateDishViewModel();    

                newDish.DishId = id;
                newDish.DishName = dish.DishName;
                newDish.DishPrice = dish.DishPrice;
                newDish.MenuType = dish.MenuType;
                newDish.AccessoriesList = _accessoriesService.All();
                newDish.ListAccessoriesId = listAccessories;


                if (ModelState.IsValid && editDish != null)
                {


                    foreach (int AccessoryId in listAccessories)
                    {
                       
                        CreateDishsAccessoriesViewModel dishAccessoryRemove = new CreateDishsAccessoriesViewModel();


                        dishAccessoryRemove.AccessoryId = AccessoryId;
                        dishAccessoryRemove.DishId = id;
                        _dishsAccessoriesService.Remove(dishAccessoryRemove);

                    }

                    foreach (int AccessoryId in editDish.ListAccessoriesId)
                    {
                        CreateDishsAccessoriesViewModel dishAccessory = new CreateDishsAccessoriesViewModel();

                        dishAccessory.AccessoryId = AccessoryId;
                        dishAccessory.DishId = id;
                        _dishsAccessoriesService.Add(dishAccessory);

                    }
                    editDish.ListAccessoriesId = listAccessories;
                    editDish.AccessoriesList = _accessoriesService.All();
                    _dishService.Edit(id, editDish);

                    return RedirectToAction("PrivateIndex");
                }
                return View(newDish);
            }
            catch
            {
                return View();
            }
        }

        // GET: DishController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DishController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dishService.Remove(id);

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
