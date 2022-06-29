using System.Collections.Generic;
using Lussans_Halen_V1.Models.ViewModels;

namespace Lussans_Halen_V1.Models.Service
{
    public interface IReservationService
    {
        Reservation Add(CreateReservationViewModel reservation);
        List<Reservation> All();
        List<Reservation> Search(string search);
        Reservation FindById(int id);
        bool Edit(int id, CreateReservationViewModel reservation);
        bool Remove(int id);
    }
}
