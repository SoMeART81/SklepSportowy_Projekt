using Microsoft.Extensions.Hosting;
using SklepSportowy.Models;

namespace SklepSportowy.Services
{
    public interface ISprzetSportowyService
    {
        public int Save(SprzetSportowy sprzet);

        public bool Delete(int? id);

        public ICollection<SprzetSportowy> FindAll();

        public bool Update(SprzetSportowy sprzet);




        public bool DodanieFirmy(Firma firma, int id);

        public SprzetSportowy? FindByFirmy(int? id);

        public SprzetSportowy? FindByRelations(int? id);




        public bool DodaniePromocji(Promocja promocja, int id);

        public SprzetSportowy? FindByPromocja(int? id);








        public int DodanieDanych(Dane dane);



        public ICollection<Dane> FindAlDane();






    }
}
