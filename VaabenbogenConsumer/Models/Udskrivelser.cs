namespace VaabenbogenConsumer.Models
{
    public class Udskrivelser
    {
        public int Id { get; set; }
        public DateTime Created {  get; set; }
        public string CreatedBy { get; set; }
        public Virksomhed? UdskrevetTilVirksomhed { get; set; }
        public Jaeger? UdskrevetTilJaeger { get; set; }

        public Udskrivelser(int id, DateTime created, string createdBy, Virksomhed? udskrevetTilVirksomhed, Jaeger? udskrevetTilJaeger)
        {
            Id = id;
            Created = DateTime.UtcNow;
            CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
            UdskrevetTilVirksomhed = udskrevetTilVirksomhed ?? throw new ArgumentNullException(nameof(udskrevetTilVirksomhed));
            UdskrevetTilJaeger = udskrevetTilJaeger ?? throw new ArgumentNullException(nameof(udskrevetTilJaeger));
        }

        public Udskrivelser()
        {
            Created = DateTime.UtcNow;
            CreatedBy = "";
        }
    }
}
