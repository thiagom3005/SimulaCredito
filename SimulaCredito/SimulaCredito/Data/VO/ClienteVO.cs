using SimulaCredito.Hypermedia;
using SimulaCredito.Hypermedia.Abstract;
using SimulaCredito.Models;

namespace SimulaCredito.Data.VO
{
    public class ClienteVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public double Celular { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Financiamento>? Financiamentos { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}