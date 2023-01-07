using SklepSportowy.Models;
using Microsoft.EntityFrameworkCore;

namespace SklepSportowy.Services
{
    public class SprzetSportowyServiceEF : ISprzetSportowyService
    {
        private readonly AppDbContext _context;

        public SprzetSportowyServiceEF(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }

            var find = _context.SprzetSportowy.Find(id);
            if (find is not null)
            {
                _context.SprzetSportowy.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<SprzetSportowy> FindAll()
        {
            return _context.SprzetSportowy.ToList();
        }

        public int Save(SprzetSportowy sprzętSportowy)
        {
            try
            {
                var entityEntry = _context.SprzetSportowy.Add(sprzętSportowy);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }
    }
}
