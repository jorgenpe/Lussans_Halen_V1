using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IAllergyService
    {
        Allergy Add(CreateAllergyViewModel allergy);
        List<Allergy> All();
        List<Allergy> Search(string search);
        Allergy FindById(int id);
        bool Edit(int id, CreateAllergyViewModel allergy);
        bool Remove(int id);
    }
}
