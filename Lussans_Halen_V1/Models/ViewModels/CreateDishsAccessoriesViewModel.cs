using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateDishsAccessoriesViewModel
    {

        public int DishId { get; set; }

        public int AccessoryId { get; set; }
        public List<int> ListAcceriesId;
    }
}
