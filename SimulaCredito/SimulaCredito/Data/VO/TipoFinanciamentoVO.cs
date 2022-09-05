using SimulaCredito.Hypermedia;
using SimulaCredito.Hypermedia.Abstract;
using SimulaCredito.Models;

namespace SimulaCredito.Data.VO
{
    public class TipoFinanciamentoVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Taxa { get; set; }
        public double ValorMin { get; set; }
        public double ValorMax { get; set; }
        public int QtdMinParcelas { get; set; }
        public int QtdMaxParcelas { get; set; }

        public ICollection<Financiamento>? Financiamentos { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
