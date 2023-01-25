using Microsoft.EntityFrameworkCore;
using System;

namespace SklepSportowy.Models
{
    public class AppDbContext : DbContext   
    {
        public DbSet<SprzetSportowy> SprzetSportowy { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Promocja> Promocja { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "ASP.NET 6.0.0", ReleaseDate = DateTime.Parse("2022-02-13"), Created = DateTime.Now },
                new Book() { Id = 2, Title = "C# 10.0", ReleaseDate = DateTime.Parse("2022-02-13"), Created = DateTime.Now },
                new Book() { Id = 3, Title = "Java 19", ReleaseDate = DateTime.Parse("2021-12-23"), Created = DateTime.Now },
                new Book() { Id = 4, Title = "JavaScript", ReleaseDate = DateTime.Parse("2022-08-05"), Created = DateTime.Now },
                new Book() { Id = 5, Title = "Node.js", ReleaseDate = DateTime.Parse("2019-10-10"), Created = DateTime.Now }
            );
            */
        }
    }
}
