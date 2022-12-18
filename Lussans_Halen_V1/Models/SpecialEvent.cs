
using System.ComponentModel.DataAnnotations;


namespace Lussans_Halen_V1.Models
{
    public class SpecialEvent
    {
        [Key]
        public int SpecialEventsId { get; set; }
        public string SpecialEventsInfoName { get; set; }
        public string SpecialEventsDiscription { get; set; }
    }
}
