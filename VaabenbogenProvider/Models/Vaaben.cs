



namespace VaabenbogenProvider.Models
{
    public class Vaaben(int id, string navn, string fabrikat, string ladefunktion, string loebenummer, string type, Ejer ejer) : IEquatable<Vaaben?>
    {
        public int Id { get; set; } = id;
        public string Navn { get; set; } = navn ?? throw new ArgumentNullException(nameof(navn));
        public string Fabrikat { get; set; } = fabrikat ?? throw new ArgumentNullException(nameof(fabrikat));
        public string Ladefunktion { get; set; } = ladefunktion ?? throw new ArgumentNullException(nameof(ladefunktion));
        public string Loebenummer { get; set; } = loebenummer ?? throw new ArgumentNullException(nameof(loebenummer));
        public string Type { get; set; } = type ?? throw new ArgumentNullException(nameof(type));
        public Ejer Ejer { get; set; } = ejer ?? throw new ArgumentNullException(nameof(ejer));

        public override bool Equals(object? obj)
        {
            return Equals(obj as Vaaben);
        }

        public bool Equals(Vaaben? other)
        {
            return other is not null &&
                   Id == other.Id &&
                   Navn == other.Navn &&
                   Fabrikat == other.Fabrikat &&
                   Ladefunktion == other.Ladefunktion &&
                   Loebenummer == other.Loebenummer &&
                   Type == other.Type &&
                   EqualityComparer<Ejer>.Default.Equals(Ejer, other.Ejer);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Navn, Fabrikat, Ladefunktion, Loebenummer, Type, Ejer);
        }

        public static bool operator ==(Vaaben? left, Vaaben? right)
        {
            return EqualityComparer<Vaaben>.Default.Equals(left, right);
        }

        public static bool operator !=(Vaaben? left, Vaaben? right)
        {
            return !(left == right);
        }
    }
}
