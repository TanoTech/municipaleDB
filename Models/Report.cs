namespace Municipale.Models
{
    public class Report
    {
        public string? Trasgressore { get; set; }
        public DateTime DataViolazione { get; set; }
        public string? IndirizzoViolazione { get; set; }
        public decimal Importo { get; set; }
        public int TotaleVerbali { get; set; }
        public int TotalePuntiDecurtati { get; set; }
    }

}