using Microsoft.Extensions.Hosting;
using SklepSportowy.Models;

namespace SklepSportowy.Services
{
    public interface ISprzętSportowyService
    {
        public int Save(SprzętSportowy but);

        public bool Delete(int? id);

        public ICollection<SprzętSportowy> FindAll();
    }
}
