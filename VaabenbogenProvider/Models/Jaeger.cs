namespace VaabenbogenProvider.Models
{
    public class Jaeger : IEquatable<Jaeger?>
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public DateOnly Foedselsdato { get; set; }
        public string JaegerId { get; set; }
        public string? Telefon { get; set; }
        public string? Mobil { get; set; }
        public string Email { get; set; }
        public ICollection<Vaaben>? TilknyttedeVaaben { get; set; }

        public Jaeger()
        {
        }

        public Jaeger(int id, string fornavn, string efternavn, DateOnly foedselsdato, string jaegerId, string email)
        {
            Id = id;
            Fornavn = fornavn ?? throw new ArgumentNullException(nameof(fornavn));
            Efternavn = efternavn ?? throw new ArgumentNullException(nameof(efternavn));
            Foedselsdato = foedselsdato;
            JaegerId = jaegerId ?? throw new ArgumentNullException(nameof(jaegerId));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public Jaeger(int id, string fornavn, string efternavn, DateOnly foedselsdato, string jaegerId, string? telefon, string? mobil, string email, ICollection<Vaaben>? tilknyttedeVaaben)
        {
            Id = id;
            Fornavn = fornavn ?? throw new ArgumentNullException(nameof(fornavn));
            Efternavn = efternavn ?? throw new ArgumentNullException(nameof(efternavn));
            Foedselsdato = foedselsdato;
            JaegerId = jaegerId ?? throw new ArgumentNullException(nameof(jaegerId));
            Telefon = telefon;
            Mobil = mobil;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            TilknyttedeVaaben = tilknyttedeVaaben;
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
                   Email == other.Email &&
                   EqualityComparer<ICollection<Vaaben>?>.Default.Equals(TilknyttedeVaaben, other.TilknyttedeVaaben);
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
            hash.Add(TilknyttedeVaaben);
            return hash.ToHashCode();
        }
    }
}
