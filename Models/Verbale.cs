namespace Municipale.Models
{
    public class Verbale
    {
        public int ID { get; set; }

        public DateTime DataViolazione { get; set; }

        public string? IndirizzoViolazione { get; set; }

        public int IDAgente { get; set; }

        public DateTime DataTrascrizioneVerbale { get; set; }

        public decimal Importo { get; set; }

        public int DecurtamentoPunti { get; set; }
        public int IDAnagrafe { get; set; }
        public int IDTipoViolazione { get; set; }
        
    }
}