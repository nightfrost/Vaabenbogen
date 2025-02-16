using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models.ViewModels
{
    public record SoegVaabenRecord(string? Navn, string? Fabrikant, Ladefunktion? Ladefunktion, [Display(Name = "Løbenummer")] string? Loebenummer, [Display(Name = "Våben type")] VaabenType? Type, VaabenStatus? Status);

    public class SoegVaaben
    {
        public string? Navn { get; set; }
        public string? Fabrikant { get; set; }
        public Ladefunktion? Ladefunktion { get; set; }
        [Display(Name = "Systemnummer")]
        public string? Systemnummer { get; set; }
        [Display(Name = "Pibenummer")]
        public string? Pibenummer { get; set; }
        [Display(Name = "Bundstykkenummer")]
        public string? Bundstykkenummer { get; set; }
        [Display(Name = "Våben type")]
        public VaabenType? Type { get; set; }
        public VaabenStatus? Status { get; set; }
        [Display(Name = "Vis udskrevet?")]
        public bool IsUdskrevet { get; set; }

        public SoegVaaben()
        {
            this.IsUdskrevet = false;
        }

        public SoegVaaben(string? navn, string? fabrikant, Ladefunktion? ladefunktion, string? loebenummer, VaabenType? type, VaabenStatus? status, bool? isUdskrevet)
        {
            Navn = navn;
            Fabrikant = fabrikant;
            Ladefunktion = ladefunktion;
            Bundstykkenummer = loebenummer;
            Type = type;
            Status = status;
            IsUdskrevet = isUdskrevet ?? false;
        }

        public SoegVaaben(string? navn, string? fabrikant, Ladefunktion? ladefunktion, string? systemnummer, string? pibenummer, string? bundstykkenummer, VaabenType? type, VaabenStatus? status, bool? isUdskrevet)
        {
            Navn = navn;
            Fabrikant = fabrikant;
            Ladefunktion = ladefunktion;
            Systemnummer = systemnummer;
            Pibenummer = pibenummer;
            Bundstykkenummer = bundstykkenummer;
            Type = type;
            Status = status;
            IsUdskrevet = isUdskrevet ?? false;
        }
    }
}
