namespace Lussans_Halen_V1.Models
{
    public class DishAccessory
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int AccessoryId { get; set; }
        public Accessory Accessory { get; set; }
    }
}
