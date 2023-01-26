
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepSportowy.Models
{
    public class Dane
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię")]
        [StringLength(50)]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko")]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Proszę podać email")]
        [StringLength(50)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Proszę podać numer telefonu")]
        public string NumerTelefonu { get; set; } 
    }
}
