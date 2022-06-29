using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbDishRepo : IDishRepo
    {

        readonly LussansDbContext _lussansDbContext;

        public DbDishRepo(LussansDbContext lussansDbContext)
        {
            _lussansDbContext = lussansDbContext;   
        }

        public Dish Create(Dish dish)
        {
            _lussansDbContext.Add(dish);
            _lussansDbContext.SaveChanges();

            return dish;
        }

        public bool Delete(Dish dish)
        {
            _lussansDbContext.Remove(dish);

            int change = _lussansDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false; 
        }

        public List<Dish> Read()
        {
            if(_lussansDbContext.Dishes == null)
            {
                return null;
            }
            return _lussansDbContext.Dishes.ToList();
        }

        public Dish Read(int id)
        {
            if (_lussansDbContext.Dishes == null)
            {
                return null;
            }
            return _lussansDbContext.Dishes.SingleOrDefault(p => p.dishId == id); 
        }

        public bool Update(Dish dish)
        {
            _lussansDbContext.Update(dish);

            int change = _lussansDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false; ;
        }
    }
}
