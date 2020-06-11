using System.ComponentModel.DataAnnotations;

namespace Werkcollege05.Oef01.Models
{
    public class Persoon
    {
        [Required]
        public string Naam { get; set; }

        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Wachtwoord))]
        public string WachtwoordControle { get; set; }

        // [DataType(DataType.EmailAddress)] gaat ook, maar zorgt enkel voor client-side validatie, omdat DataType louter het type attribuut van het gegenereerde html element zal bepalen
        [EmailAddress]
        public string Email { get; set; }

        [Range(0, 150)]
        public int Leeftijd { get; set; }

        [RegularExpression("The Curse of Monkey Island")]
        public string FavorietSpel { get; set; }
    }
}