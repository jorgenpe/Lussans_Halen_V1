using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface IDishsAccessoriesRepo
    {

        DishAccessory Create(DishAccessory dishAccessory);
        List<DishAccessory> Read();
        List<DishAccessory> ReadByDishI(int id);
        List<DishAccessory> ReadByAccessoryId(int id);
        bool Update(DishAccessory dishAccessory);
        bool Delete(DishAccessory dishAccessory);

    }
}
