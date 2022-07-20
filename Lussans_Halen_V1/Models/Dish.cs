using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Lussans_Halen_V1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lussans_Halen_V1.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string DishName { get; set; }

        [DisplayFormat(DataFormatString = "{ 0:0.##}, ApplyFormatInEditMode= true")]
        public decimal DishPrice { get; set; }
        public MenuType MenuType { get; set; }

        public List<DishAccessory> DishAccessories { get; set; }
        public List<DishWeekMenu> DishWeekMenuList { get; set; }

    }
}
