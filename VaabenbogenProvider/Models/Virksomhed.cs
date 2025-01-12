namespace VaabenbogenProvider.Models
{
    public class Virksomhed : Ejer, IEquatable<Virksomhed?>
    {
        public string Cvr { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string ZipCode { get; set; }
        public string By { get; set; }
        public DateOnly StartDato { get; set; }
        public DateOnly? EndDato { get; set; }

        public Virksomhed()
        {
        }

        // Constructor with minimal parameters
        public Virksomhed(int id, string cvr, string navn, string adresse, string zipCode, string by, DateOnly startDato, DateOnly? endDato)
            : base(id, string.Empty, string.Empty, null) // Call base class constructor with default values
        {
            Cvr = cvr ?? throw new ArgumentNullException(nameof(cvr));
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
            Adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
            ZipCode = zipCode ?? throw new ArgumentNullException(nameof(zipCode));
            By = by ?? throw new ArgumentNullException(nameof(by));
            StartDato = startDato;
            EndDato = endDato;
        }

        // Constructor with all parameters
        public Virksomhed(int id, string cvr, string navn, string adresse, string zipCode, string by, string telefon, string email, DateOnly startDato, DateOnly? endDato)
            : base(id, telefon, email, null)
        {
            Cvr = cvr ?? throw new ArgumentNullException(nameof(cvr));
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
            Adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
            ZipCode = zipCode ?? throw new ArgumentNullException(nameof(zipCode));
            By = by ?? throw new ArgumentNullException(nameof(by));
            StartDato = startDato;
            EndDato = endDato;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Virksomhed);
        }

        public bool Equals(Virksomhed? other)
        {
            return other is not null &&
                   Cvr == other.Cvr &&
                   Navn == other.Navn &&
                   Adresse == other.Adresse &&
                   ZipCode == other.ZipCode &&
                   By == other.By &&
                   Telefon == other.Telefon &&
                   Email == other.Email &&
                   StartDato.Equals(other.StartDato) &&
                   EqualityComparer<DateOnly?>.Default.Equals(EndDato, other.EndDato);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Cvr);
            hash.Add(Navn);
            hash.Add(Adresse);
            hash.Add(ZipCode);
            hash.Add(By);
            hash.Add(Telefon);
            hash.Add(Email);
            hash.Add(StartDato);
            hash.Add(EndDato);
            return hash.ToHashCode();
        }

        public static bool operator ==(Virksomhed? left, Virksomhed? right)
        {
            return EqualityComparer<Virksomhed>.Default.Equals(left, right);
        }

        public static bool operator !=(Virksomhed? left, Virksomhed? right)
        {
            return !(left == right);
        }
    }
}
