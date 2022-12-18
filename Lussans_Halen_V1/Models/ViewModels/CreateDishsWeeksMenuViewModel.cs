
using System.Collections.Generic;


namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateDishsWeeksMenuViewModel
    {

        public int DishId { get; set; }
        public List<int> ListDishId { get; set; }

        public int WeekMenuId { get; set; }

        public List<int> ListWeekMenuId { get; set; }   
        public List<Dish> DishList { get; set; }
        public List<DishWeekMenu> ListWeekMenu { get; set; }

    }
}
