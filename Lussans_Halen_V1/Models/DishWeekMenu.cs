namespace Lussans_Halen_V1.Models
{
    public class DishWeekMenu
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int WeekMenuId { get; set; }
        public WeekMenu WeekMenu { get; set; }
    }
}
