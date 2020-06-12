using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Werkcollege05.Oef02.Models
{
    public class Gebruiker
    {
        [Key]
        public string Naam { get; set; }

        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [NotMapped]
        [Display(Name = "Herhaal wachtwoord"), DataType(DataType.Password)]
        [Compare(nameof(Wachtwoord), ErrorMessage = "Wachtwoorden komen niet overeen")]
        public string WachtwoordControle { get; set; }
    }
}
