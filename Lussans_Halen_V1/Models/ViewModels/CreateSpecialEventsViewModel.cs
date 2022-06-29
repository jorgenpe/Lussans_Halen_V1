using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateSpecialEventsViewModel
    {
        public int SpecialEventsId { get; set; }
        public string SpecialEventsName { get; set; }
        public string SpecialEventsDiscription { get; set; }
    }
}
