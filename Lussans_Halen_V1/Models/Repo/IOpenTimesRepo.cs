using System.Collections.Generic;


namespace Lussans_Halen_V1.Models.Repo
{
    public interface IOpenTimesRepo
    {

        OpenTimes Create(OpenTimes openTimes);
        List<OpenTimes> Read();
        OpenTimes Read(int id);
        bool Update(OpenTimes openTimes);
        bool Delete(OpenTimes openTimes);
    }
}
