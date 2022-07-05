using Lussans_Halen_V1.Models.ViewModels;
using System.Collections.Generic;

using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;

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
            WeekMenu _WeekMenu = new WeekMenu() { WeekMenuId = 0, WeekNumber = weekMenu.WeekNumber, Day = weekMenu.Day };

            _weekMenuRepo.Create(_WeekMenu);
            return _WeekMenu;
        }

        public List<WeekMenu> All()
        {
            return _weekMenuRepo.Read();
        }

        public bool Edit(int id, CreateWeekMenuViewModel weekMenu)
        {
            WeekMenu _WeekMenu = new WeekMenu() { WeekMenuId = id, WeekNumber = weekMenu.WeekNumber, Day = weekMenu.Day };


            return _weekMenuRepo.Update(_WeekMenu);

        }

        public WeekMenu FindById(int id)
        {
            return _weekMenuRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _weekMenuRepo.Delete(FindById(id));
        }

        public List<WeekMenu> Search(int search)
        {
            List<WeekMenu> _WeekMenu = new List<WeekMenu>();

            foreach(WeekMenu weekMenu in _weekMenuRepo.Read())
            {
                if(weekMenu.WeekNumber == search) 
                {
                    _WeekMenu.Add(weekMenu);
                }
            }
            return _WeekMenu;
        }
    }
}
