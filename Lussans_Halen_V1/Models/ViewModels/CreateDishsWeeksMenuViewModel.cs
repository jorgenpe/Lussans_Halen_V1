using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateDishsWeeksMenuViewModel
    {

        public int DishId { get; set; }
        public List<int> ListDishId { get; set; }

        public int WeekMenuId { get; set; }
        public List<int> ListWeekMenuId { get; set; }   


    }
}
