
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Lussans_Halen_V1.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string DishName { get; set; }

        [DisplayFormat(DataFormatString = "{ 0:0.##}, ApplyFormatInEditMode= true")]
        public double DishPrice { get; set; }
        public MenuType MenuType { get; set; }

        public List<DishAccessory> DishAccessories { get; set; }
        public List<DishWeekMenu> DishWeekMenuList { get; set; }

    }
}
