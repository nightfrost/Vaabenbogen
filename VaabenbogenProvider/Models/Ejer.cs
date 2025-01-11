namespace VaabenbogenProvider.Models
{
    public class Ejer
    {
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string? Mobil { get; set; }
        public List<Vaaben>? TilknyttedeVaaben { get; set; }
    }
}
