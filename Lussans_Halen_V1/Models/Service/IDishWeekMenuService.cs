using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IDishWeekMenuService
    {
        DishWeekMenu Add(CreateDishsWeeksMenuViewModel createDishsWeeksMenuViewMode);
        List<DishWeekMenu> All();
        DishWeekMenu FindById(CreateDishsWeeksMenuViewModel createDishsWeeksMenuViewMode);
        
        bool Remove(CreateDishsWeeksMenuViewModel deleteDishWeeksMenu);
    }
}
