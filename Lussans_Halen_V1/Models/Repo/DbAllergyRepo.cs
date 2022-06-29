using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbAllergyRepo : IAllergyRepo
    {
        readonly LussansDbContext _lussansDbContext;

        public DbAllergyRepo(LussansDbContext lussansDbContext)
        {
            _lussansDbContext = lussansDbContext;
        }

        public Allergy Create(Allergy allergy)
        {
            _lussansDbContext.Add(allergy);
            _lussansDbContext.SaveChanges();

            return allergy;

        }

        public bool Delete(Allergy allergy)
        {
            _lussansDbContext.Remove(allergy);
            int change = _lussansDbContext.SaveChanges();
            
            if (change == 2) { return true; }

            return false;
        }

        public List<Allergy> Read()
        {
            if(_lussansDbContext.Allergies == null)
            {
                return null;
            }
            return _lussansDbContext.Allergies.ToList();
        }

        public Allergy Read(int id)
        {
            if (_lussansDbContext.Allergies == null)
            {
                return null;
            }
            return _lussansDbContext.Allergies.SingleOrDefault(p => p.AllergyId == id); 
        }

        public bool Update(Allergy allergy)
        {
            _lussansDbContext.Update(allergy);
            int change = _lussansDbContext.SaveChanges();

            if (change == 2) { return true; }

            return false; ;
        }
    }
}
