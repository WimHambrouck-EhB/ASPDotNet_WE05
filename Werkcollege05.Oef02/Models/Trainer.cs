using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Werkcollege05.Oef02.Models
{
    public class Trainer : Gebruiker
    {
        public int Id { get; set; }
        [NotMapped]
        public List<Pokemon> Pokemon { get; set; }
    }
}
