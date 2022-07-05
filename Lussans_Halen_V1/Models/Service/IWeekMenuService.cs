using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IWeekMenuService
    {
        WeekMenu Add(CreateWeekMenuViewModel weekMenu);
        List<WeekMenu> All();
        List<WeekMenu> Search(int search);
        WeekMenu FindById(int id);
        bool Edit(int id, CreateWeekMenuViewModel weekMenu);
        bool Remove(int id);
    }
}
