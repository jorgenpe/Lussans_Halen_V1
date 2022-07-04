using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface IWeekMenuRepo
    {
        WeekMenu Create(WeekMenu weekMenu);
        List<WeekMenu> Read();
        WeekMenu Read(int id);
        bool Update(WeekMenu weekMenu);
        bool Delete(WeekMenu weekMenu);
    }
}
