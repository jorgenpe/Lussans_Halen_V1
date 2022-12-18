using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lussans_Halen_V1.Models.ViewModels;
using System.Collections.Generic;
using Lussans_Halen_V1.Models.Repo;
using System.Globalization;


namespace Lussans_Halen_V1.Models.Service
{
    public class WeekMenuService : IWeekMenuService
    {

        private readonly IWeekMenuRepo _weekMenuRepo;

        public WeekMenuService(IWeekMenuRepo weekMenuRepo)
        {
            _weekMenuRepo = weekMenuRepo;
        }

        public WeekMenu Add(CreateWeekMenuViewModel weekMenu)
        {
            WeekMenu _WeekMenu = new WeekMenu() { WeekMenuId = 0, DayPrice = weekMenu.DayPrice, WeekNumber = weekMenu.WeekNumber, Day = weekMenu.Day, DayAccessories = weekMenu.DayAccessories  };

            _weekMenuRepo.Create(_WeekMenu);
            return _WeekMenu;
        }

        public List<WeekMenu> All()
        {
            return _weekMenuRepo.Read();
        }

        public bool Edit(int id, CreateWeekMenuViewModel weekMenu)
        {
            WeekMenu _weekMenu = _weekMenuRepo.Read(id);
            if(weekMenu != null)
            {
                
                _weekMenu.DayPrice = weekMenu.DayPrice;
                _weekMenu.WeekNumber = weekMenu.WeekNumber;
                _weekMenu.Day = weekMenu.Day;
                _weekMenu.DayAccessories = weekMenu.DayAccessories;
                return _weekMenuRepo.Update(_weekMenu);

            }
            return false;
         
        }

        public WeekMenu FindById(int id)
        {
            return _weekMenuRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _weekMenuRepo.Delete(FindById(id));
        }
    }
}
