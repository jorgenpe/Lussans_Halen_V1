using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbDishsWeekMenusRepo : IDishWeekMenuRepo
    {

         private readonly LussansDbContext _lussansDbContext;

        public DbDishsWeekMenusRepo(LussansDbContext lussansDbContext)
        {
            _lussansDbContext = lussansDbContext;
        }

        public DishWeekMenu Create(DishWeekMenu dishWeekMenu)
        {
            _lussansDbContext.DishWeekMenus.Add(dishWeekMenu);
            return dishWeekMenu;
        }

        public bool Delete(DishWeekMenu dishWeekMenu)
        {
            _lussansDbContext.DishWeekMenus.Remove(dishWeekMenu);
            return _lussansDbContext.SaveChanges() > 0;
        }

        public List<DishWeekMenu> Read()
        {
            return _lussansDbContext.DishWeekMenus.ToList();
        }

        public List<DishWeekMenu> ReadByDishId(int id)
        {
            return _lussansDbContext.DishWeekMenus
                .Where(dI => dI.DishId == id)
                .ToList();
        }

        public List<DishWeekMenu> ReadByWeekMenuId(int id)
        {
            return _lussansDbContext.DishWeekMenus
                .Where(wI => wI.WeekMenuId == id)
                .ToList();
        }

        public bool Update(DishWeekMenu dishWeekMenu)
        {
            _lussansDbContext.DishWeekMenus.Update(dishWeekMenu);
            return _lussansDbContext.SaveChanges() > 0;
        }
    }
}
