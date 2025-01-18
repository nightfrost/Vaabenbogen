using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models.ViewModels
{
    public record SoegVaabenRecord(string? Navn, string? Fabrikant, Ladefunktion? Ladefunktion, [Display(Name = "Løbenummer")] string? Loebenummer, [Display(Name = "Våben type")] VaabenType? Type, VaabenStatus? Status);

    public class SoegVaaben
    {
        public string? Navn { get; set; }
        public string? Fabrikant { get; set; }
        public Ladefunktion? Ladefunktion { get; set; }
        [Display(Name = "Løbenummer")]
        public string? Loebenummer { get; set; }
        [Display(Name = "Våben type")]
        public VaabenType? Type { get; set; }
        public VaabenStatus? Status { get; set; }

        public SoegVaaben()
        {
        }

        public SoegVaaben(string? navn, string? fabrikant, Ladefunktion? ladefunktion, string? loebenummer, VaabenType? type, VaabenStatus? status)
        {
            Navn = navn;
            Fabrikant = fabrikant;
            Ladefunktion = ladefunktion;
            Loebenummer = loebenummer;
            Type = type;
            Status = status;
        }
    }
}
