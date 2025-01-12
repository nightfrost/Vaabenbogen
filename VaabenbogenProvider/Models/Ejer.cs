
namespace VaabenbogenProvider.Models
{
    public class Ejer
    {
        public int Id { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string? Mobil { get; set; }

        public Ejer()
        {
        }

        public Ejer(int id, string telefon, string email, string? mobil)
        {
            Id = id;
            Telefon = telefon ?? throw new ArgumentNullException(nameof(telefon));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Mobil = mobil;
        }
    }
}
