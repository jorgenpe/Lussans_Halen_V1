using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IOpenTimesService
    {
        OpenTimes Add(CreateOpenTimesViewModel openTimes);
        List<OpenTimes> All();
        List<OpenTimes> Search(string search);
        OpenTimes FindById(int id);
        bool Edit(int id, CreateOpenTimesViewModel openTimes);
        bool Remove(int id);
    }
}
