using Microsoft.EntityFrameworkCore;
using System;

namespace SklepSportowy.Models
{
    public class AppDbContext : DbContext   
    {
        public DbSet<SprzetSportowy> SprzetSportowy { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Promocja> Promocja { get; set; }





        public DbSet<Dane> Dane { get; set; }





        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
          
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Dane>().HasData(
                new Dane() { Id = 1, Imie = "Maciej", Nazwisko = "Kowalski", Email = "maciejkowalski@gmail.com" },
                new Dane() { Id = 2, Imie = "Ewa", Nazwisko = "Janysz", Email = "ewajanysz@gmail.com" },
                new Dane() { Id = 3, Imie = "Robert", Nazwisko = "Jarosz", Email = "robertjarosz@gmail.com" },
                new Dane() { Id = 4, Imie = "Anna", Nazwisko = "Nowak", Email = "annanowak@gmail.com" },
                new Dane() { Id = 5, Imie = "Filip", Nazwisko = "Strojny", Email = "filipstrojny.com" }
            );
            
        }
        */
    }
}
