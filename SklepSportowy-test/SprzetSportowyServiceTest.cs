using Microsoft.EntityFrameworkCore;
using SklepSportowy.Models;
using SklepSportowy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepSportowy_test
{
    internal class SprzetSportowyServiceTest : ISprzetSportowyService
    {
        private readonly Dictionary<int, SprzetSportowy> sprzet;

        public SprzetSportowyServiceTest()
        {
            sprzet = new Dictionary<int, SprzetSportowy>();
            sprzet.Add(1, new SprzetSportowy() { Id = 1, NazwaSprzetu = "Koszulka", ModelSprzetu = "IK6", Cena = 200, Firmy = new List<Firma>(), Promocje = new List<Promocja>() });
        }

        public bool Delete(int? id)
        {
            return sprzet.Remove((int)id);
        }

        public int DodanieDanych(Dane dane)
        {
            throw new NotImplementedException();
        }

        public bool DodanieFirmy(Firma firma, int id)
        {
            throw new NotImplementedException();
        }

        public bool DodaniePromocji(Promocja promocja, int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Dane> FindAlDane()
        {
            throw new NotImplementedException();
        }

        public ICollection<SprzetSportowy> FindAll()
        {
            List<SprzetSportowy> sprzety = new List<SprzetSportowy>();
            foreach (var item in sprzet)
            {
                sprzety.Add(item.Value);
            }
            return sprzety;
        }

        public SprzetSportowy? FindByFirmy(int? id)
        {
            throw new NotImplementedException();
        }

        public SprzetSportowy? FindByPromocja(int? id)
        {
            throw new NotImplementedException();
        }

        public SprzetSportowy? FindByRelations(int? id)
        {
            if (sprzet.ContainsKey((int)id))
            {
                return sprzet[(int)id];
            }
            else
            {
                return null;
            }
        }

        public int Save(SprzetSportowy sprzet)
        {
            try
            {
                this.sprzet.Add(this.sprzet.Count() + 1, sprzet);
                return this.sprzet.Count() + 1;
            }
            catch
            {
                return -1;
            }
        }

        public bool Update(SprzetSportowy sprzet)
        {
            if (!this.sprzet.ContainsKey(sprzet.Id)) return false;

            var find = this.sprzet[sprzet.Id];
            if (find is not null)
            {
                find.NazwaSprzetu = sprzet.NazwaSprzetu;
                find.ModelSprzetu = sprzet.ModelSprzetu;
                find.Cena = sprzet.Cena;
                find.Promocje = sprzet.Promocje;
                find.Firmy = sprzet.Firmy;
                return true;
            }
            return false;
        }
    }
}
