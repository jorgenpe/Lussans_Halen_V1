using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Service
{
    public class AllergyService : IAllergyService
    {
        private readonly IAllergyRepo _allergyRepo;

        public AllergyService(IAllergyRepo allergyRepo) 
        { 
            _allergyRepo = allergyRepo; 
        }

        public Allergy Add(CreateAllergyViewModel allergy)
        {
            Allergy _allergy = new Allergy() { AllergyId = 0, AllergyInfoName = allergy.AllergyInfoName, AllergyInfo = allergy.AllergyInfo,
                 
            };

            _allergyRepo.Create(_allergy);

            return _allergy;
        }

        public List<Allergy> All()
        {
            if(_allergyRepo != null)
            {
                return _allergyRepo.Read();
            }
            return null;
        }

        public bool Edit(int id, CreateAllergyViewModel allergy)
        {
            Allergy _allergy = _allergyRepo.Read(id);

            _allergy.AllergyId = id;
            _allergy.AllergyInfoName = allergy.AllergyInfoName;
            _allergy.AllergyInfo = allergy.AllergyInfo;

            return _allergyRepo.Update(_allergy);
        }

        public Allergy FindById(int id)
        {
            return _allergyRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _allergyRepo.Delete(FindById(id));
        }

        public List<Allergy> Search(string search)
        {
            List<Allergy> _allergies = new List<Allergy>();

            foreach(Allergy allergy in _allergyRepo.Read())
            {
                if(allergy.AllergyInfoName == search) 
                { 
                    _allergies.Add(allergy); 
                }
            }

            return _allergies;
        }
    }
}
