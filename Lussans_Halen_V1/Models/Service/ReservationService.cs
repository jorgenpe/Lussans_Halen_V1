using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models.Repo;
using System.Collections.Generic;

namespace Lussans_Halen_V1.Models.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepo _reservationRepo;

        public ReservationService(IReservationRepo reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }

        public Reservation Add(CreateReservationViewModel reservation)
        {
            Reservation newReservation = new Reservation() { ReservationId = 0, ReservationName = reservation.ReservationName,
                ReservationDescription = reservation.ReservationDescription};

            _reservationRepo.Create(newReservation);
            return newReservation;

        }

        public List<Reservation> All()
        {
            if(_reservationRepo != null)
            {
                return _reservationRepo.Read();
            }
            return null;
            
        }

        public bool Edit(int id, CreateReservationViewModel reservation)
        {
            Reservation reservationToUpdate = _reservationRepo.Read(id);


            reservationToUpdate.ReservationId = id;
            reservationToUpdate.ReservationName = reservation.ReservationName;
            reservationToUpdate.ReservationDescription = reservation.ReservationDescription;

           return _reservationRepo.Update(reservationToUpdate);
        }

        public Reservation FindById(int id)
        {
            return _reservationRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _reservationRepo.Delete(FindById(id));
        }

        public List<Reservation> Search(string search)
        {
            List<Reservation> _reservations = new List<Reservation>();

            foreach( Reservation reservation in _reservationRepo.Read())
            {
                if( reservation.ReservationName == search)
                {
                    _reservations.Add(reservation);
                }
            }
            return _reservations;
        }
    }
}
