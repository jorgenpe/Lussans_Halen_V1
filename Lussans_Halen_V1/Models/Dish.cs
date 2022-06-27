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
        public int Id { get; set; }
        public string DishName { get; set; }
        public decimal DishPrice { get; set; }
        public string MenuTyp { get; set; }

        [ForeignKey("Accessory")]
        public int AccessoryId { get; set; }
        public Accessory AccessoryName { get; set; }

        //[ForeignKey("Allergy")]
       //public int AllergyId { get; set; }
        public Allergy AllergyInfo { get; set; }

    }
}
