using Microsoft.EntityFrameworkCore;
using System;

namespace SklepSportowy.Models
{
    public class AppDbContext : DbContext   
    {
        public DbSet<SprzetSportowy> SprzetSportowy { get; set; }
        public DbSet<Firma> Firma { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
