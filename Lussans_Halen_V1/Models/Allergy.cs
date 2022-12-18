
using System.ComponentModel.DataAnnotations;


namespace Lussans_Halen_V1.Models
{
    
    public class Allergy
    {
        [Key]
        public int AllergyId { get; set; }
        public string AllergyInfoName { get; set; }
        public string AllergyInfo { get; set; }
    }
}
