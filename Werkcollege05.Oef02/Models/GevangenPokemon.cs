using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Werkcollege05.Oef02.Models
{
    /// <summary>
    /// Verwijzing naar een bestaande Pokémon in het systeem met extra info zoals levenspunten, kracht, snelheid, ...
    /// Waarom 2 Pokémon modellen? Als we het bestaande Pokémonmodel koppelen aan een trainer, kan elke Pokémon in het systeem slechts 1 keer gevangen worden.
    /// </summary>
    public class GevangenPokemon
    {
        public int Id { get; set; }
        
        [ForeignKey("Pokemon")]
        public int BasePokemon { get; set; }
        public Pokemon Pokemon { get; set; }

        public int Levenspunten { get; set; }
        public int Kracht { get; set; }
        public int Snelheid { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
