using SimulaCredito.Hypermedia;
using SimulaCredito.Hypermedia.Abstract;
using SimulaCredito.Models;

namespace SimulaCredito.Data.VO
{
    public class ParcelaVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public int NumeroParcela { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

        public long FinanciamentoId { get; set; }
        public Financiamento financiamento { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
