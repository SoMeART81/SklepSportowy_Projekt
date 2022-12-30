using SklepSportowy.Models;
using Microsoft.EntityFrameworkCore;

namespace SklepSportowy.Services
{
    public class SprzętSportowyServiceEF : ISprzętSportowyService
    {
        private readonly AppDbContext _context;

        public SprzętSportowyServiceEF(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }

            var find = _context.SprzętSportowy.Find(id);
            if (find is not null)
            {
                _context.SprzętSportowy.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<SprzętSportowy> FindAll()
        {
            return _context.SprzętSportowy.ToList();
        }

        public int Save(SprzętSportowy sprzętSportowy)
        {
            try
            {
                var entityEntry = _context.SprzętSportowy.Add(sprzętSportowy);
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
