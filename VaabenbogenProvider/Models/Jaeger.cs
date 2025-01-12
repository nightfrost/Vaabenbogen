namespace VaabenbogenProvider.Models
{
    public class Jaeger : Ejer, IEquatable<Jaeger?>
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public DateOnly Foedselsdato { get; set; }
        public string JaegerId { get; set; }

        public Jaeger()
        {
        }

        // Constructor with fewer parameters
        public Jaeger(int id, string fornavn, string efternavn, DateOnly foedselsdato, string jaegerId, string email)
            : base(id, string.Empty, email, null) // Call base class constructor with default values
        {
            Fornavn = fornavn ?? throw new ArgumentNullException(nameof(fornavn));
            Efternavn = efternavn ?? throw new ArgumentNullException(nameof(efternavn));
            Foedselsdato = foedselsdato;
            JaegerId = jaegerId ?? throw new ArgumentNullException(nameof(jaegerId));
        }

        // Constructor with all parameters
        public Jaeger(int id, string fornavn, string efternavn, DateOnly foedselsdato, string jaegerId, string? telefon, string? mobil, string email)
            : base(id, telefon, email, mobil)
        {
            Fornavn = fornavn ?? throw new ArgumentNullException(nameof(fornavn));
            Efternavn = efternavn ?? throw new ArgumentNullException(nameof(efternavn));
            Foedselsdato = foedselsdato;
            JaegerId = jaegerId ?? throw new ArgumentNullException(nameof(jaegerId));
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Jaeger);
        }

        public bool Equals(Jaeger? other)
        {
            return other is not null &&
                   Id == other.Id &&
                   Fornavn == other.Fornavn &&
                   Efternavn == other.Efternavn &&
                   Foedselsdato.Equals(other.Foedselsdato) &&
                   JaegerId == other.JaegerId &&
                   Telefon == other.Telefon &&
                   Mobil == other.Mobil &&
                   Email == other.Email;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Fornavn);
            hash.Add(Efternavn);
            hash.Add(Foedselsdato);
            hash.Add(JaegerId);
            hash.Add(Telefon);
            hash.Add(Mobil);
            hash.Add(Email);
            return hash.ToHashCode();
        }
    }
}
