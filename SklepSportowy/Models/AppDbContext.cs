using Microsoft.EntityFrameworkCore;
using System;

namespace SklepSportowy.Models
{
    public class AppDbContext : DbContext   
    {
        public DbSet<SprzętSportowy> SprzętSportowy { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
