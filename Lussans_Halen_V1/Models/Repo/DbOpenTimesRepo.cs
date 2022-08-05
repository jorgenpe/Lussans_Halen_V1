using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    
    public class DbOpenTimesRepo : IOpenTimesRepo
    {
        
        readonly LussansDbContext _lussansDbContext;

        public DbOpenTimesRepo(LussansDbContext lussansDbContext)
        {
            _lussansDbContext = lussansDbContext;
        }

        public OpenTimes Create(OpenTimes openTimes)
        {
            _lussansDbContext.Add(openTimes);
            _lussansDbContext.SaveChanges(); 
            
            return openTimes;   
        }

        public bool Delete(OpenTimes openTimes)
        {
            _lussansDbContext.Remove(openTimes);
            int change = _lussansDbContext.SaveChanges();

            if(change == 2)
            {
                return true;
            }
            return false;
        }

        public List<OpenTimes> Read()
        {
            if(_lussansDbContext.OpensTimes == null)
            {
                return null;
            }

            return _lussansDbContext.OpensTimes.ToList();
        }

        public OpenTimes Read(int id)
        {

            if (_lussansDbContext.OpensTimes == null)
            {
                return null;
            }

            return _lussansDbContext.OpensTimes.SingleOrDefault(p=> p.OpenTimesId == id);
        }

        public bool Update(OpenTimes openTimes)
        {
            _lussansDbContext.Update(openTimes);
            int change = _lussansDbContext.SaveChanges();

            if (change == 2)
            {
                return true;
            }
            return false; ;
        }
    }
}
