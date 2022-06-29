using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Lussans_Halen_V1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lussans_Halen_V1.Models
{
    public class Accessory
    {
        [Key]
        public int AccessoryId { get; set; }
        public string AccessoryName { get; set; }

        //public List<Dish> Dishes { get; set; }

        public List<DishAccessory> DishAccessories { get; set; }
    }
}
