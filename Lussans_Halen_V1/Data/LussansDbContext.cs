using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lussans_Halen_V1.Models;

namespace Lussans_Halen_V1.Data
{
    
    

    public class LussansDbContext : IdentityDbContext<AccountPerson>
    {
        public LussansDbContext(DbContextOptions<LussansDbContext> options) : base(options)
        {


        }

        
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<DishAccessory> DishAccessories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string AdminId = Guid.NewGuid().ToString();
            string AdminRoleId = Guid.NewGuid().ToString();
            string UserRoleId = Guid.NewGuid().ToString();


            modelBuilder.Entity<Dish>()
                .HasOne(a => a.AccessoryName)
                .WithMany(b => b.Dishes)
                .HasForeignKey(a => a.AccessoryId);

            modelBuilder.Entity<Dish>()
                .HasOne(a => a.AllergyInfo)
                .WithOne(b => b.Dish)
                .HasForeignKey<Allergy>(b => b.DishId);
           
                            

            modelBuilder.Entity<DishAccessory>().HasKey(pl =>
                new {
                    pl.DishId,
                    pl.AccessoryId
                });


            modelBuilder.Entity<DishAccessory>()
                .HasOne(pl => pl.Dish)
                .WithMany(p => p.DishAccessories)
                .HasForeignKey(pl => pl.DishId);

            modelBuilder.Entity<DishAccessory>()
                .HasOne(pl => pl.Accessory)
                .WithMany(p => p.DishAccessories)
                .HasForeignKey(pl => pl.AccessoryId);



                            /* modelBuilder.Entity<AccountPerson>().HasData(new AccountPerson
                             {
                                 Id = AdminId,
                                 UserName = "Admin",
                                 Email = "admin@gmail.com",
                                 PasswordHash = new PasswordHasher<AccountPerson>().HashPassword(null, "Qwer€321"),
                                 FirstName = "Bob",
                                 LastName = "Hope",
                                 EmailConfirmed = true,
                                 DateOfBirth = DateTime.Now,
                                 AccessFailedCount = 0,

                             });

                             modelBuilder.Entity<AccountPerson>().HasData(
                                 new IdentityRole
                                 {
                                     Id = AdminRoleId,
                                     Name = "Admin"
                                 },
                                 new IdentityRole
                                 {
                                     Id = UserRoleId,
                                     Name = "User"
                                 }
                                 );

                             modelBuilder.Entity<AccountPerson>().HasData(
                                 new IdentityUserRole<string>
                                 {
                                     UserId = AdminId,
                                     RoleId = AdminRoleId
                                 });*/

        }
    }
    
}
