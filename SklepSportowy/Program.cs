using Microsoft.EntityFrameworkCore;
using SklepSportowy.Models;
using SklepSportowy.Services;
using Microsoft.AspNetCore.Identity;
using SklepSportowy.Data;
using System.Text.Json.Serialization;

namespace SklepSportowy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("UserContextConnection") ?? throw new InvalidOperationException("Connection string 'UserContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration["Data:Connection"])
            );
            builder.Services.AddDbContext<UserContext>(
                options => options.UseSqlServer(builder.Configuration["Data:Connection"])
            );

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UserContext>();
            

            builder.Services.AddScoped<ISprzetSportowyService, SprzetSportowyServiceEF>();

            builder.Services.AddMvc().AddJsonOptions(
             options => options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.Preserve
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}