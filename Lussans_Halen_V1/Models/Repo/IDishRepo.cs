using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface IDishRepo
    {

        Dish Create(Dish dish);
        List<Dish> Read();
        Dish Read(int id);
        bool Update(Dish dish);
        bool Delete(Dish dish);

    }
}
