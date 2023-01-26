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

            var szukaj = _context.SprzetSportowy.Find(id);
            if (szukaj is not null)
            {
                _context.SprzetSportowy.Remove(szukaj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<SprzetSportowy> FindAll()
        {
            return _context.SprzetSportowy.Include(p => p.Firmy).Include(p => p.Promocje).ToList();
        }

        public int Save(SprzetSportowy sprzetSportowy)
        {
            try
            {
                var entityEntry = _context.SprzetSportowy.Add(sprzetSportowy);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool Update(SprzetSportowy sprzet)
        {
            try
            {
                SprzetSportowy? szukaj = _context.SprzetSportowy.Find(sprzet.Id);
                if (szukaj is not null)
                {
                    szukaj.NazwaSprzetu = sprzet.NazwaSprzetu;
                    szukaj.ModelSprzetu = sprzet.ModelSprzetu;
                    szukaj.Cena = sprzet.Cena;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public bool DodanieFirmy(Firma firma, int id)
        {
            SprzetSportowy? sprzetSportowy = _context.SprzetSportowy.Include(e => e.Firmy).Where(e => e.Id == id).FirstOrDefault();
            if (sprzetSportowy is null)
            {
                return false;
            }

            sprzetSportowy.Firmy.Add(firma);
            _context.SprzetSportowy.Update(sprzetSportowy);
            _context.SaveChanges();

            return true;
        }


        public SprzetSportowy? FindByFirmy(int? id)
        {
            SprzetSportowy? sprzetSportowy = _context.SprzetSportowy.Include(e => e.Firmy).Where(e => e.Id == id).FirstOrDefault();
            if (id is null)
            {
                return null;
            }
            else
            {
                return sprzetSportowy;
            }
        }







        public SprzetSportowy? FindByRelations(int? id)
        {
            return id is null ? null : _context.SprzetSportowy.Include(p => p.Firmy).Where(p => p.Id == id).Include(e => e.Promocje).Where(e => e.Id == id).FirstOrDefault();
        }




        public bool DodaniePromocji(Promocja promocja, int id)
        {
            SprzetSportowy? sprzetSportowy = _context.SprzetSportowy.Include(e => e.Promocje).Where(e => e.Id == id).FirstOrDefault();
            if (sprzetSportowy is null)
            {
                return false;
            }

            sprzetSportowy.Promocje.Add(promocja);
            _context.SprzetSportowy.Update(sprzetSportowy);
            _context.SaveChanges();

            return true;
        }


        public SprzetSportowy? FindByPromocja(int? id)
        {
            SprzetSportowy? sprzetSportowy = _context.SprzetSportowy.Include(e => e.Promocje).Where(e => e.Id == id).FirstOrDefault();
            if (id is null)
            {
                return null;
            }
            else
            {
                return sprzetSportowy;
            }
        }








        public int DodanieDanych(Dane dane)
        {
            try
            {
                var entityEntry = _context.Dane.Add(dane);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }

        public ICollection<Dane> FindAlDane()
        {
            return _context.Dane.ToList();
        }








    }
}
