using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Lussans_Halen_V1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lussans_Halen_V1.Models
{
    public class WeekMenu
    {
        [Key]
        public int WeekMenuId { get; set; }
        [Required]
        [StringLength(128)]
        public int WeekNumber { get; set; }
        public Weekday Day { get; set; }

        public List<DishWeekMenu> dishWeekMenuList { get; set; }

    }
}
