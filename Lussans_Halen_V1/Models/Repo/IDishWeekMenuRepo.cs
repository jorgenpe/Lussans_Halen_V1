using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface IDishWeekMenuRepo
    {

        DishWeekMenu Create(DishWeekMenu dishWeekMenu);
        List<DishWeekMenu> Read();
        List<DishWeekMenu> ReadByDishId(int id);
        List<DishWeekMenu> ReadByWeekMenuId(int id);
        bool Update(DishWeekMenu dishWeekMenu);
        bool Delete(DishWeekMenu dishWeekMenu);
    }
}
