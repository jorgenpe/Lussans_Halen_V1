using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbDishsAccessoriesRepo : IDishsAccessoriesRepo
    {
         readonly LussansDbContext _LussansDbContext;

        public DbDishsAccessoriesRepo(LussansDbContext lussansDbContext)
        {
            _LussansDbContext = lussansDbContext;
        }

        public DishAccessory Create(DishAccessory dishAccessory)
        {
            _LussansDbContext.DishAccessories.Add(dishAccessory);
            _LussansDbContext.SaveChanges();
     
            return dishAccessory;
        }

        public bool Delete(DishAccessory dishAccessory)
        {
            _LussansDbContext.DishAccessories.Remove(dishAccessory);
            return _LussansDbContext.SaveChanges() > 0;
        }

        public List<DishAccessory> Read()
        {
            return _LussansDbContext.DishAccessories.ToList();
        }

        public List<DishAccessory> ReadByDishI(int id)
        {
            return _LussansDbContext.DishAccessories
                .Where(dI => dI.DishId == id).ToList();
        }

        public List<DishAccessory> ReadByAccessoryId(int id)
        {
            return _LussansDbContext.DishAccessories
                .Where(aI => aI.AccessoryId == id).ToList();
        }

        public bool Update(DishAccessory dishAccessory)
        {
            _LussansDbContext.DishAccessories.Update(dishAccessory);
            return _LussansDbContext.SaveChanges() > 0;
        }
    }
}
