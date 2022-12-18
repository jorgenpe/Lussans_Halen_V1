
using System.ComponentModel.DataAnnotations;


namespace Lussans_Halen_V1.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public string ReservationName { get; set;}
        public string ReservationDescription { get; set;}
    }
}
