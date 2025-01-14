

using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models
{
    public class Jaeger : Ejer, IEquatable<Jaeger?>
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Cpr { get; set; }
        [Display(Name = "Fødselsdato")]
        public DateOnly Foedselsdato { get; set; }

        public Jaeger()
        {
            Created = DateTime.UtcNow;
            CreatedBy = "System";
        }

        public Jaeger(string fornavn, string efternavn, string cpr, int id, string telefon, string email, string mobil, string jaegerId) : base(id, telefon, email, mobil, jaegerId)
        {
            Fornavn = fornavn ?? throw new ArgumentNullException(nameof(fornavn));
            Efternavn = efternavn ?? throw new ArgumentNullException(nameof(efternavn));
            Cpr = cpr ?? throw new ArgumentNullException(nameof(cpr));
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Jaeger);
        }

        public bool Equals(Jaeger? other)
        {
            return other is not null &&
                   Id == other.Id &&
                   Telefon == other.Telefon &&
                   Email == other.Email &&
                   Mobil == other.Mobil &&
                   JaegerId == other.JaegerId &&
                   Created == other.Created &&
                   CreatedBy == other.CreatedBy &&
                   Updated == other.Updated &&
                   UpdatedBy == other.UpdatedBy &&
                   Fornavn == other.Fornavn &&
                   Efternavn == other.Efternavn &&
                   Cpr == other.Cpr &&
                   Foedselsdato.Equals(other.Foedselsdato);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Telefon);
            hash.Add(Email);
            hash.Add(Mobil);
            hash.Add(JaegerId);
            hash.Add(Created);
            hash.Add(CreatedBy);
            hash.Add(Updated);
            hash.Add(UpdatedBy);
            hash.Add(Fornavn);
            hash.Add(Efternavn);
            hash.Add(Cpr);
            hash.Add(Foedselsdato);
            return hash.ToHashCode();
        }

        public static bool operator ==(Jaeger? left, Jaeger? right)
        {
            return EqualityComparer<Jaeger>.Default.Equals(left, right);
        }

        public static bool operator !=(Jaeger? left, Jaeger? right)
        {
            return !(left == right);
        }
    }
}
