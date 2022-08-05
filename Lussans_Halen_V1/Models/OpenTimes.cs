using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Lussans_Halen_V1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lussans_Halen_V1.Models
{
    public class OpenTimes
    {
        public int OpenTimesId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{ HH:mm}")]
        public DateTime OpenTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{ HH:mm}")]
        public DateTime CloseTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{ HH:mm}")]
        public DateTime DayMenuTimeStart { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{ HH:mm}")]
        public DateTime DayMenuTimeEnd { get; set; }

        public Weekday Day { get; set; }
        public string DayTimeOption { get; set; }
    }
}
