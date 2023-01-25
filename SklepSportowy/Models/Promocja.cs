using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepSportowy.Models
{
    public class Promocja
    {

        [HiddenInput]
        [Key]
        public int PromocjaId { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę Firmy")]
        [MaxLength(100, ErrorMessage = "...")]  //// ilosc symbolow max 100  
        [MinLength(0, ErrorMessage = "...")] /// min 0 symbowl
        public string NazwaPromocji { get; set; }
        public int WartoscPromocji { get; set; }




        public int SprzetId { get; set; }

        public SprzetSportowy? SprzetSportowy { get; set; }
    }
}