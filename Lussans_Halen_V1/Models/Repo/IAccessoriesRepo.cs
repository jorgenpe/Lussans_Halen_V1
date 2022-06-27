using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface IAccessoriesRepo
    {
        Accessory Create(Accessory accessory);
        List<Accessory> Read();
        Accessory Read(int id);
        bool Update(Accessory accessory);
        bool Delete(Accessory accessory);
    }
}
