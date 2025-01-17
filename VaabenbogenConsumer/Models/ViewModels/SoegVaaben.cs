using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models.ViewModels
{
    public record SoegVaaben(string? Navn, string? Fabrikant, Ladefunktion? Ladefunktion, [Display(Name = "Løbenummer")] string? Loebenummer, [Display(Name = "Våben type")] VaabenType? Type, VaabenStatus? Status);
}
