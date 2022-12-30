using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepSportowy.Models
{
    public class SprzętSportowy
    {

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Proszę podać nazwe")]
        [StringLength(50)]
        public string NazwaSprzętu { get; set; }



        [Required(ErrorMessage = "Proszę podać nazwe!")]
        [StringLength(50)]
        public string ModelSprzętu { get; set; }


        [Required(ErrorMessage = "Proszę podać cenę")]
        [Range(0, 100000, ErrorMessage = "Proszę podać cenę, od 0 do 100 000.")]
        public double Cena { get; set; }
    }
}
