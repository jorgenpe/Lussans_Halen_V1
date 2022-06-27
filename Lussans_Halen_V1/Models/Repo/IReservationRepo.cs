using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Repo
{
    public interface IReservationRepo
    {
        Reservation Create(Reservation reservation);
        List<Reservation> Read();
        Reservation Read(int id);
        bool Update(Reservation reservation);
        bool Delete(Reservation reservation);
    }
}
