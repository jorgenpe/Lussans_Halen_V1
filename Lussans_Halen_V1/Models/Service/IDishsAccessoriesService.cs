using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IDishAccessoriesService
    {
        DishAccessory Add(CreateDishsAccessoriesViewModel createDishsAccessoriesViewModel);
        List<DishAccessory> All();
        DishAccessory FindById(CreateDishsAccessoriesViewModel createDishsAccessoriesViewModel);
        bool Remove(CreateDishsAccessoriesViewModel createDishsAccessoriesViewModel);

    }
}
