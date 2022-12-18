
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Lussans_Halen_V1.Models
{
    public class Accessory
    {
        [Key]
        public int AccessoryId { get; set; }
        public string AccessoryName { get; set; }

        public List<DishAccessory> DishAccessories { get; set; }
    }
}
