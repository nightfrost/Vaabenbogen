using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models.ViewModels
{
    public class SoegKunde
    {
        public bool? IsFirma { get; set; }
        public string Query { get; set; }

        public SoegKunde()
        {
        }

        public SoegKunde(bool? isFirma, string query)
        {
            IsFirma = isFirma;
            Query = query ?? throw new ArgumentNullException(nameof(query));
        }
    }
}
