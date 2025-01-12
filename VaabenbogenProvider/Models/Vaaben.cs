



namespace VaabenbogenProvider.Models
{
    public class Vaaben : IEquatable<Vaaben?>
    {
        public int Id { get; set; }
        public string Navn { get; set; } 
        public string Fabrikat { get; set; } 
        public string Ladefunktion { get; set; }
        public string Loebenummer { get; set; }
        public string Type { get; set; }
        public Ejer Ejer { get; set; }

        public Vaaben()
        {
        }

        public Vaaben(int id, string navn, string fabrikat, string ladefunktion, string loebenummer, string type, Ejer ejer)
        {
            Id = id;
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
            Fabrikat = fabrikat ?? throw new ArgumentNullException(nameof(fabrikat));
            Ladefunktion = ladefunktion ?? throw new ArgumentNullException(nameof(ladefunktion));
            Loebenummer = loebenummer ?? throw new ArgumentNullException(nameof(loebenummer));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Ejer = ejer ?? throw new ArgumentNullException(nameof(ejer));
        }

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
