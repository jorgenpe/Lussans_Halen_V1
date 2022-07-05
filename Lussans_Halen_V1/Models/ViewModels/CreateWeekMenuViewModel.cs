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
        public int WeekNumber { get; set; }
        public Weekday Day { get; set; }

        public List<DishWeekMenu> DishWeekMenuList { get; set; }

        
        
    }
}
