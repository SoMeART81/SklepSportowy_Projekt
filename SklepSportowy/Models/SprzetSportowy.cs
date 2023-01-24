using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepSportowy.Models
{
    public class SprzetSportowy
    {
        public SprzetSportowy()
        {
            Firmy = new List<Firma>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę sprzętu")]
        [StringLength(50)]
        public string NazwaSprzetu { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę modelu")]
        [StringLength(50)]
        public string ModelSprzetu { get; set; }

        [Required(ErrorMessage = "Proszę podać cenę")]
        [Range(0, 100000, ErrorMessage = "Proszę podać cenę, od 0 do 100 000.")]
        public double Cena { get; set; }

        virtual public List<Firma> Firmy { get; set; }
    }
}
