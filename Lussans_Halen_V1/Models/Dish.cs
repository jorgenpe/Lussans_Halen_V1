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
        public int DishPrice { get; set; }

        [ForeignKey("Accessories")]
        public int AccessoriesId { get; set; }
        public string Accessories { get; set; }

        [ForeignKey("Allergy")]
        public int AllergyId { get; set; }
        public string AllergyInfo { get; set; }

    }
}
