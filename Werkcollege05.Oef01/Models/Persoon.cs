using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Werkcollege05.Oef01.Models
{
    public class Persoon
    {
        public int ID { get; set; }
        [Required]
        public string Naam { get; set; }

        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Wachtwoord))]
        public string WachtwoordControle { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Range(0, 150)]
        public int Leeftijd { get; set; }
        
        [FavorietSpel]
        public string FavorietSpel { get; set; }
    }
}
