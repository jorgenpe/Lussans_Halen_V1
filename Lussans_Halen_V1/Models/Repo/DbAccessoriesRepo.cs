using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbAccessoriesRepo : IAccessoriesRepo
    {

        readonly LussansDbContext _lussansDbContext;

        public DbAccessoriesRepo(LussansDbContext lussansDbContext)
        {
            _lussansDbContext = lussansDbContext;
        }


        public Accessory Create(Accessory accessory)
        {
            _lussansDbContext.Add(accessory);
            _lussansDbContext.SaveChanges();

            return accessory;

        }

        public bool Delete(Accessory accessory)
        {
            _lussansDbContext.Remove(accessory);

            int change = _lussansDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false; ;
        }

        public List<Accessory> Read()
        {
            if (_lussansDbContext.Accessories == null)
            {
                return null;
            }
            return _lussansDbContext.Accessories
                .ToList(); 
        }

        public Accessory Read(int id)
        {
            if (_lussansDbContext.Accessories == null)
            {
                return null;
            }
            return _lussansDbContext.Accessories
                .SingleOrDefault(p => p.AccessoryId == id) ;
        }

        public bool Update(Accessory accessory)
        {
            _lussansDbContext.Update(accessory);

            int change = _lussansDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false; 
       
        }
    }
}
