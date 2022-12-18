using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateDishViewModel
    {
       
        public int DishId { get; set; }
        [Required]
        [StringLength(255)]
        public string DishName { get; set; }
        [Required]
        public double DishPrice { get; set; }
        [Required]
        public MenuType MenuType { get; set; }


        public int AccessoriesId { get; set; }
        public string Accessories { get; set; }

        
        public int AllergyId { get; set; }
        public Allergy AllergyInfo { get; set; }

        public List<int> ListAccessoriesId { get; set; }
        public List<DishAccessory> DishAccessories { get; set; }
        public List<DishWeekMenu> DishWeekMenuList { get; set; }
        public List<Accessory> AccessoriesList { get; set; }
        public List<Dish> DishList { get; set; }
        
        public bool IsEven { get; set; }

    }
}
