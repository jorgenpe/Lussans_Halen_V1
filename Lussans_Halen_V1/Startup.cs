using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lussans_Halen_V1.Data;
using Lussans_Halen_V1.Models;
using Lussans_Halen_V1.Models.Repo;
using Lussans_Halen_V1.Models.Service;
using Lussans_Halen_V1.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Lussans_Halen_V1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LussansDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();


            services.AddScoped<IDishRepo, DbDishRepo>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IAccessoriesRepo, DbAccessoriesRepo>();
            services.AddScoped<IAccessoriesService, AccessoriesService>();
            services.AddScoped<IAllergyRepo, DbAllergyRepo>();
            services.AddScoped<IAllergyService, AllergyService>();
            services.AddScoped<IReservationRepo, DbReservationRepo>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<ISpecialEventsRepo, DbSpecialEventsRepo>();
            services.AddScoped<ISpecialEventsService, SpecialEventsService>();
            services.AddScoped<IContactRepo, DbContactRepo>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IWeekMenuRepo, DbWeekMenuRepo>();
            services.AddScoped<IWeekMenuService, WeekMenuService>();

            services.AddDistributedMemoryCache();



            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc();

            // //Will be used later maybe
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddRazorPages();


            services.AddIdentity<AccountPerson, IdentityRole>()
                .AddEntityFrameworkStores<LussansDbContext>()
                .AddDefaultTokenProviders();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "PrivateHome",
                    pattern: "Private/Lussan",
                    defaults: new {controller = "PrivateHome", action="Index"});

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
