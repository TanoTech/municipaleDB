using Municipale.Models;

namespace Municipale.ViewModels
{
    public class Home
    {
        public Anagrafica? Anagrafica { get; set; }
        public Verbale? Verbale { get; set; }
        public List<Anagrafica>? Anagrafiche { get; set; }
        public List<Agente>? Agenti { get; set; }
        public List<TipoViolazione>? TipiViolazione { get; set; }
    }
}
