﻿using SklepSportowy.Models;
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
    }
}
