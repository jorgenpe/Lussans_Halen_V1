using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface ISpecialEventsService
    {

        SpecialEvent Add(CreateSpecialEventsViewModel specialEvent);
        List<SpecialEvent> All();
        List<SpecialEvent> Search(string search);
        SpecialEvent FindById(int id);
        bool Edit(int id, CreateSpecialEventsViewModel specialEvent);
        bool Remove(int id);
    }
}
