using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Lussans_Halen_V1.Models.Service
{
    public class DishWeekMenuService : IDishWeekMenuService
    {
        private readonly IDishWeekMenuRepo _dishWeekMenuRepo;
        private readonly IDishService _dishService;

        public DishWeekMenuService(IDishWeekMenuRepo dishWeekMenuRepo, IDishService dishService)
        {
            _dishWeekMenuRepo = dishWeekMenuRepo;
            _dishService = dishService;
        }

        public DishWeekMenu Add(CreateDishsWeeksMenuViewModel dishWeeksMenu)
        {
            if (_dishService.FindById(dishWeeksMenu.DishId) == null)
            {
                throw new ArgumentNullException("Id is not in database");
            }

            DishWeekMenu dishWeekMenu = new DishWeekMenu()
            {
                DishId = dishWeeksMenu.DishId, 
                WeekMenuId = dishWeeksMenu.WeekMenuId
                
            };
            return _dishWeekMenuRepo.Create(dishWeekMenu);
        }

        public List<DishWeekMenu> All()
        {
            return _dishWeekMenuRepo.Read();
        }
  

        public DishWeekMenu FindById(CreateDishsWeeksMenuViewModel dishWeeksMenu)
        {
            DishWeekMenu dishWeekMenuId = _dishWeekMenuRepo
                .ReadByWeekMenuId(dishWeeksMenu.WeekMenuId)
                .SingleOrDefault(dI => dI.DishId == dishWeeksMenu.DishId);
            return dishWeekMenuId;
        }

        public bool Remove(CreateDishsWeeksMenuViewModel deleteDishWeeksMenu)
        {
            DishWeekMenu dishWeekMenu = _dishWeekMenuRepo
                .ReadByWeekMenuId(deleteDishWeeksMenu.WeekMenuId)
                .SingleOrDefault(dI => dI.DishId == deleteDishWeeksMenu.DishId);

            if(dishWeekMenu != null)
            {
                return _dishWeekMenuRepo.Delete(dishWeekMenu);
            }
            return false;
        }

    }
}
