namespace VaabenbogenProvider.Models
{
    public class Jaeger(string id, string fornavn, string efternavn, DateOnly foedselsdato, string jaegerId, string? telefon, string? mobil, ICollection<Vaaben>? tilknyttedeVaaben, string email) : IEquatable<Jaeger?>
    {
        public string Id { get; set; } = id ?? throw new ArgumentNullException(nameof(id));
        public string Fornavn { get; set; } = fornavn ?? throw new ArgumentNullException(nameof(fornavn));
        public string Efternavn { get; set; } = efternavn ?? throw new ArgumentNullException(nameof(efternavn));
        public DateOnly Foedselsdato { get; set; } = foedselsdato;
        public string JaegerId { get; set; } = jaegerId ?? throw new ArgumentNullException(nameof(jaegerId));
        public string? Telefon { get; set; } = telefon;
        public string? Mobil { get; set; } = mobil;
        public string Email { get; set; } = email ?? throw new ArgumentNullException(nameof(email));
        public ICollection<Vaaben>? TilknyttedeVaaben { get; set; } = tilknyttedeVaaben;

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
