
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Lussans_Halen_V1.Models
{
    public class WeekMenu
    {
        [Key]
        public int WeekMenuId { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{ 0:0.##}, ApplyFormatInEditMode= true")]
        public double DayPrice { get; set; }    
        public int WeekNumber { get; set; }
        public Weekday Day { get; set; }
        public string DayAccessories { get; set; }

        public List<DishWeekMenu> DishWeekMenuList { get; set; }

    }
}
