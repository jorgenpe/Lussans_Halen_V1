using System.Collections.Generic;
using Lussans_Halen_V1.Data;
using System.Linq;

namespace Lussans_Halen_V1.Models.Repo
{
    public class DbReservationRepo : IReservationRepo
    {
        readonly LussansDbContext _lussansDbContext;

        public DbReservationRepo(LussansDbContext lussansDbContext)
        {
            _lussansDbContext = lussansDbContext;
        }

        public Reservation Create(Reservation reservation)
        {
            _lussansDbContext.Add(reservation);
            _lussansDbContext.SaveChanges();
            return reservation;
        }

        public bool Delete(Reservation reservation)
        {
            _lussansDbContext.Remove(reservation);
            int change = _lussansDbContext.SaveChanges();

            if(change == 2) { return true; }
            return false;
        }

        public List<Reservation> Read()
        {
            if(_lussansDbContext.Reservations == null)
            {
                return null;
            }
            return _lussansDbContext.Reservations.ToList();
        }

        public Reservation Read(int id)
        {
            if (_lussansDbContext.Reservations == null)
            {
                return null;
            }

            return _lussansDbContext.Reservations.SingleOrDefault(p=> p.ReservationId == id);
        }

        public bool Update(Reservation reservation)
        {
            _lussansDbContext.Update(reservation);
            int change = _lussansDbContext.SaveChanges();

            if (change == 2) { return true; }
            return false;
        }
    }
}
