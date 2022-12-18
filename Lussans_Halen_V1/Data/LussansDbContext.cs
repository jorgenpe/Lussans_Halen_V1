using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<WeekMenu> WeekMenus { get; set; }
        public DbSet<DishWeekMenu> DishWeekMenus { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<OpenTimes> OpensTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string AdminId = Guid.NewGuid().ToString();
            string AdminRoleId = Guid.NewGuid().ToString();
            string UserRoleId = Guid.NewGuid().ToString();

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

            modelBuilder.Entity<DishWeekMenu>().HasKey(pl =>
                new {
                    pl.DishId,
                    pl.WeekMenuId
                });

            modelBuilder.Entity<DishWeekMenu>()
                .HasOne(pl => pl.Dish)
                .WithMany(p => p.DishWeekMenuList)
                .HasForeignKey(pl => pl.DishId);

            modelBuilder.Entity<DishWeekMenu>()
                .HasOne(pl => pl.WeekMenu)
                .WithMany(p => p.DishWeekMenuList)
                .HasForeignKey(pl => pl.WeekMenuId);
        }
    }  
}
