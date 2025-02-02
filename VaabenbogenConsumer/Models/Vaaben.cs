

using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models
{
    public class Vaaben
    {
        public int Id { get; set; }
        public string Navn { get; set; } 
        public string Fabrikant { get; set; } 
        public Ladefunktion Ladefunktion { get; set; }
        [Display(Name = "Løbenummer")]
        public string Loebenummer { get; set; }
        [Display(Name = "Våben type")]
        public VaabenType Type { get; set; }
        [Display(Name = "Våben status")]
        public VaabenStatus Status { get; set; }
        public Ejer? Ejer { get; set; }
        [Display(Name = "Oprettet")]
        public DateTime? Created { get; set; }
        [Display(Name = "Oprettet af")]
        public string? CreatedBy { get; set; }
        [Display(Name ="Opdateret")]
        public DateTime? Updated { get; set; }
        [Display(Name = "Opdateret af")]
        public string? UpdatedBy { get; set; }
        [Display(Name = "Udskrevet")]
        public bool? IsUdskrevet { get; set; }
        public DateTime? Udskrevet { get; set; }
        public string Indskriver { get; set; }

        public Vaaben()
        {
            Created = DateTime.UtcNow;
            IsUdskrevet = false;
        }

        public Vaaben(int id, string navn, string fabrikant, Ladefunktion ladefunktion, string loebenummer, VaabenType type, VaabenStatus status, Ejer? ejer)
        {
            Id = id;
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
            Fabrikant = fabrikant ?? throw new ArgumentNullException(nameof(fabrikant));
            Ladefunktion = ladefunktion;
            Loebenummer = loebenummer ?? throw new ArgumentNullException(nameof(loebenummer));
            Type = type;
            Status = status;
            Ejer = ejer;
            Created = DateTime.UtcNow;
            IsUdskrevet = false;
        }
    }

    public enum VaabenType
    {
        Haglgevær = 0,
        Pibe = 1,
        Riffel = 2,
    }

    public enum VaabenStatus
    {
        
        Reperation = 0,
        Opbevaring = 1,
        [Display(Name = "Køb og salg")]
        KoebOgSalg = 2,
        Kommision = 3,
    }

    public enum Ladefunktion
    {
        Manuel = 0,
        Automatisk = 2,
        Halvautomatisk = 3,
    }
}
