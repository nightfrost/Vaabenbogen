using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models
{
    public class Ejer
    {
        public int Id { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Mobil { get; set; }
        [Display(Name = "JægerID")]
        public string JaegerId { get; set; }
        [Display(Name = "Oprettet")]
        public DateTime? Created { get; set; }
        [Display(Name = "Oprettet af")]
        public string? CreatedBy { get; set; }
        [Display(Name = "Opdateret")]
        public DateTime? Updated { get; set; }
        [Display(Name = "Opdateret af")]
        public string? UpdatedBy { get; set; }
        public Ejer()
        {
            Created = DateTime.UtcNow;
            CreatedBy = "System";
        }

        public Ejer(int id, string telefon, string email, string mobil, string jaegerId)
        {
            Id = id;
            Telefon = telefon ?? throw new ArgumentNullException(nameof(telefon));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Mobil = mobil ?? throw new ArgumentNullException(nameof(mobil));
            JaegerId = jaegerId ?? throw new ArgumentNullException(nameof(jaegerId));
            Created = DateTime.UtcNow;
            CreatedBy = "System";
        }
    }
}
