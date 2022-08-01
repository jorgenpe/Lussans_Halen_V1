using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateWeekMenuViewModel
    {
        public int WeekMenuId { get; set; }
        [Required]
        [StringLength(128)]
        public double DayPrice { get; set; }
        public int WeekNumber { get; set; }
        public Weekday Day { get; set; }

        public List<int> ListDishId { get; set; }

        public List<DishWeekMenu> DishWeekMenuList { get; set; }

        
        
    }
}
