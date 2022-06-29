using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Lussans_Halen_V1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
