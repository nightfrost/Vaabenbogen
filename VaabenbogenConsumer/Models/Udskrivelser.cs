namespace VaabenbogenConsumer.Models
{
    public class Udskrivelser
    {
        public int Id { get; set; }
        public DateTime Created {  get; set; }
        public string CreatedBy { get; set; }
        public string VaabenId { get; set; }
        public string? Systemnummer { get; set; }
        public string? Pibenummer { get; set; }
        public string? Bundstykkenummer { get; set; }
        public Virksomhed? UdskrevetTilVirksomhed { get; set; }
        public Jaeger? UdskrevetTilJaeger { get; set; }

        public Udskrivelser(int id, DateTime created, string createdBy, string vaabenId, string? systemnummer, string? pibenummer, string? bundstykkenummer, Virksomhed? udskrevetTilVirksomhed, Jaeger? udskrevetTilJaeger)
        {
            Id = id;
            Created = created;
            CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
            VaabenId = vaabenId ?? throw new ArgumentNullException(nameof(vaabenId));
            Systemnummer = systemnummer;
            Pibenummer = pibenummer;
            Bundstykkenummer = bundstykkenummer;
            UdskrevetTilVirksomhed = udskrevetTilVirksomhed;
            UdskrevetTilJaeger = udskrevetTilJaeger;
        }

        public Udskrivelser()
        {
            CreatedBy = "";
            VaabenId = "";
        }
    }
}
