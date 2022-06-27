using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface IAllergyRepo
    {
        Allergy Create(Allergy allergy);
        List<Allergy> Read();
        Allergy Read(int id);
        bool Update(Allergy allergy);
        bool Delete(Allergy allergy);
    }
}
