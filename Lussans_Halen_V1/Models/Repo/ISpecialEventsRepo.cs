using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface ISpecialEventsRepo
    {
        SpecialEvent Create(SpecialEvent specialEvent);
        List<SpecialEvent> Read();
        SpecialEvent Read(int id);
        bool Update(SpecialEvent specialEvent);
        bool Delete(SpecialEvent specialEvent);
    }
}
