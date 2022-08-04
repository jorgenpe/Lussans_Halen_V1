using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;
using System.Globalization;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbWeekMenuRepo : IWeekMenuRepo
    {

        readonly LussansDbContext _lussansDbContext;

        public DbWeekMenuRepo(LussansDbContext lussansDbContext)
        {
            _lussansDbContext = lussansDbContext;
        }

        public WeekMenu Create(WeekMenu weekMenu)
        {
            _lussansDbContext.Add(weekMenu);
            _lussansDbContext.SaveChanges();
            return weekMenu;
        }

        public bool Delete(WeekMenu weekMenu)
        {
            _lussansDbContext.Remove(weekMenu);
            int change = _lussansDbContext.SaveChanges();

            if (change == 2)
            {
                return true;
            }
            return false;
        }

        public List<WeekMenu> Read()
        {
            if(_lussansDbContext.WeekMenus == null)
            {
                return null;
            }
            return _lussansDbContext.WeekMenus.ToList();
        }

        public WeekMenu Read(int id)
        {
            if (_lussansDbContext.WeekMenus == null)
            {
                return null;
            }
            return _lussansDbContext.WeekMenus.SingleOrDefault(p => p.WeekMenuId == id);
        }

        public bool Update(WeekMenu weekMenu)
        {
            _lussansDbContext.Update(weekMenu);
            int change = _lussansDbContext.SaveChanges();

            if (change == 2)
            {
                return true;
            }
            return false;
        }
    }
}
