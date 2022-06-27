using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IAccessories
    {
        Accessory Add(CreateAllergyViewModel accessory);
        List<Accessory> All();
        List<Accessory> Search(string search);
        Accessory FindById(int id);
        bool Edit(int id, CreateAccessoriesViewModel accessory);
        bool Remove(int id);
    }
}
