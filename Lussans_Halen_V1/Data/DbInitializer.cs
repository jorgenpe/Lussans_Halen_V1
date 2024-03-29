﻿
using Lussans_Halen_V1.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Lussans_Halen_V1.Data
{
    internal class DbInitializer
    {
        internal static async Task InitializeAsync(LussansDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AccountPerson> userManager)
        {

            context.Database.EnsureCreated();

            if (context.Roles.Any())//seed check
            {
                IdentityRole roleA = new IdentityRole("SuperAdmin");
                IdentityResult resultA = await roleManager.CreateAsync(roleA);
                if (!resultA.Succeeded)
                {
                    ErrorMessages(resultA);
                }
                AccountPerson accountPerson = new AccountPerson
                {
                    FirstName = "Super",
                    LastName = "SuperAdmin",
                    DateOfBirth = DateTime.Now,
                    UserName = "SuperAdmin",
                    Email = "superadmin@admin.se"
                };
                IdentityResult userResult = await userManager.CreateAsync(accountPerson, "3MjaU64ByvLu7MU!!");
                if (!userResult.Succeeded)
                {
                    ErrorMessages(userResult);
                }
                userManager.AddToRoleAsync(accountPerson, roleA.Name).Wait();
            }


            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                IdentityRole role = new IdentityRole("Admin");
                IdentityResult result = await roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    ErrorMessages(result);
                }
                //add user to role
                AccountPerson accountPerson = new AccountPerson
                {
                    FirstName = "Admina",
                    LastName = "Admin",
                    DateOfBirth = DateTime.Now,
                    UserName = "Admin",
                    Email = "admina@admin.se"
                };
                IdentityResult identityResult = await userManager.CreateAsync(accountPerson, "64Byv3MijaULu7MU!!");
                if (!identityResult.Succeeded)
                {
                    ErrorMessages(identityResult);
                }
                userManager.AddToRoleAsync(accountPerson, role.Name).Wait();
            }
        }

        private static void ErrorMessages(IdentityResult identityResult)
        {
            string errors = "";
            foreach (var error in identityResult.Errors)
            {
                errors += error.Code + ", " + error.Description;
            }
            throw new Exception(errors);

        }
    }
}
