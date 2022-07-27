using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateAccessoriesViewModel
    {

        public int AccessoriesId { get; set; }
        public string AccessoriesName { get; set; }
        public List<Accessory> ListAccessories { get; set; }

        public List<Dish> dishes { get; set; }
    }
}
