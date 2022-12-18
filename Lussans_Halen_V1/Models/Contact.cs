
using System.ComponentModel.DataAnnotations;


namespace Lussans_Halen_V1.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ExtenedContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
