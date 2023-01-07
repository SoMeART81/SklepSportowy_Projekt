using Microsoft.Extensions.Hosting;
using SklepSportowy.Models;

namespace SklepSportowy.Services
{
    public interface ISprzetSportowyService
    {
        public int Save(SprzetSportowy but);

        public bool Delete(int? id);

        public ICollection<SprzetSportowy> FindAll();
    }
}
