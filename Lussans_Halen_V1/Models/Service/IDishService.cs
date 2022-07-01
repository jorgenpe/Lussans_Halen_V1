using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IDishService
    {

        Dish Add(CreateDishViewModel dish);
        List<Dish> All();
        List<Dish> Search(string search);
        Dish FindById(int id);
        bool Edit(int id, CreateDishViewModel dish);
        bool Remove(int id);
    }
}
