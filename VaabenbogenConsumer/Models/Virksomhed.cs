

using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models
{
    public class Virksomhed : Ejer, IEquatable<Virksomhed?>
    {
        public string Cvr { get; set; }
        public string Navn { get; set; }
        public string? Adresse { get; set; }
        [Display(Name = "Postnummer")]
        public string? Zip { get; set; }
        public string? By { get; set; }
        [Display(Name = "Start dato")]
        public DateOnly? StartDato { get; set; }
        [Display(Name = "Slut dato")]
        public DateOnly? EndDato { get; set; }

        public Virksomhed()
        {
        }

        public Virksomhed(string cvr, string navn, string? adresse, string? zip, string? by, DateOnly? startDato, DateOnly? endDato, int id, string telefon, string email, string mobil, string jaegerId, string createdBy) : base(id, telefon, email, mobil, jaegerId, createdBy)
        {
            Cvr = cvr ?? throw new ArgumentNullException(nameof(cvr));
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
            Adresse = adresse;
            Zip = zip;
            By = by;
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
                   Id == other.Id &&
                   Telefon == other.Telefon &&
                   Email == other.Email &&
                   Mobil == other.Mobil &&
                   JaegerId == other.JaegerId &&
                   Created == other.Created &&
                   CreatedBy == other.CreatedBy &&
                   Updated == other.Updated &&
                   UpdatedBy == other.UpdatedBy &&
                   Cvr == other.Cvr &&
                   Navn == other.Navn &&
                   Adresse == other.Adresse &&
                   Zip == other.Zip &&
                   By == other.By &&
                   EqualityComparer<DateOnly?>.Default.Equals(StartDato, other.StartDato) &&
                   EqualityComparer<DateOnly?>.Default.Equals(EndDato, other.EndDato);
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
            hash.Add(Cvr);
            hash.Add(Navn);
            hash.Add(Adresse);
            hash.Add(Zip);
            hash.Add(By);
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
