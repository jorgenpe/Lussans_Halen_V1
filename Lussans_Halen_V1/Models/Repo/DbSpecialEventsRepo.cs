using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbSpecialEventsRepo : ISpecialEventsRepo
    {
        readonly LussansDbContext _lussanDbContext;

        public DbSpecialEventsRepo(LussansDbContext lussansDbContext)
        {
            _lussanDbContext = lussansDbContext;
        }

        public SpecialEvent Create(SpecialEvent specialEvent)
        {
            _lussanDbContext.Add(specialEvent);
            _lussanDbContext.SaveChanges();

            return specialEvent;
        }

        public bool Delete(SpecialEvent specialEvent)
        {
            _lussanDbContext.Remove(specialEvent);
            int change = _lussanDbContext.SaveChanges();

            if(change == 2)
            {
                return true;
            }
            return false;
        }

        public List<SpecialEvent> Read()
        {
            if(_lussanDbContext == null)
            {
                return null;
            }
            return _lussanDbContext.SpecialEvents.ToList();
        }

        public SpecialEvent Read(int id)
        {
            if (_lussanDbContext == null)
            {
                return null;
            }

            return _lussanDbContext.SpecialEvents.SingleOrDefault(p => p.SpecialEventsId == id);
        }

        public bool Update(SpecialEvent specialEvent)
        {
            _lussanDbContext.Update(specialEvent);
            int change = _lussanDbContext.SaveChanges();

            if (change == 2)
            {
                return true;
            }
            return false;
        }
    }
}
