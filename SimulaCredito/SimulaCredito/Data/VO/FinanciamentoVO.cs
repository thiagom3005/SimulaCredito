using SimulaCredito.Hypermedia;
using SimulaCredito.Hypermedia.Abstract;
using SimulaCredito.Models;

namespace SimulaCredito.Data.VO
{
    public class FinanciamentoVO: ISupportHyperMedia
    {
        public long Id { get; set; }
        public double ValorTotal { get; set; }
        public DateTime UltimoVencimento { get; set; }
        public double ValorTotalJuros { get; set; }
        public double TotalJuros { get; set; }

        public long ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public long TipoFinanciamentoId { get; set; }
        public TipoFinanciamento? TipoFinanciamento { get; set; }

        public ICollection<Parcela>? parcelas { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
