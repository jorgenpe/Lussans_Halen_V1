using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Lussans_Halen_V1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateOpenTimesViewModel
    {
        public int OpenTimesId { get; set; }

        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public DateTime DayMenuTimeStart { get; set; }
        public DateTime DayMenuTimeEnd { get; set; }
        public Weekday Day { get; set; }
        public string DayTimeOption { get; set; }
    }
}
