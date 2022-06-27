using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Lussans_Halen_V1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lussans_Halen_V1.Models
{
    
    public class Allergy
    {
        [Key]
        public int AllergyId { get; set; }
        public string AllergyInfo { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
