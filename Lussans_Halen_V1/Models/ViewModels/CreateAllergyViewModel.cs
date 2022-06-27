using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateAllergyViewModel
    {
        public int AllergyId { get; set; }
        public string AllergyInfo { get; set; }
    }
}
