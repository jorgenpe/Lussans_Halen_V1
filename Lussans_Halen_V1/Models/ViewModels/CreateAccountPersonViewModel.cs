using System;
using System.ComponentModel.DataAnnotations;

namespace Lussans_Halen_V1.Models.ViewModels
{
    public class CreateAccountPersonViewModel
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EMail { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(128, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
