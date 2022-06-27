using System;
using Microsoft.AspNetCore.Identity;

namespace Lussans_Halen_V1.Models
{
    public class AccountPerson : IdentityUser
    
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
           
        public DateTime DateOfBirth { get; set; }

    }
}
