using SimulaCredito.Hypermedia;
using SimulaCredito.Hypermedia.Abstract;
using SimulaCredito.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulaCredito.Models
{
    [Table("TipoFinanciamento")]
    public class TipoFinanciamento : BaseEntity, ISupportHyperMedia
    {
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Taxa")]
        public double Taxa { get; set; }
        [Column("ValorMin")]
        public double ValorMin { get; set; }
        [Column("ValorMax")]
        public double ValorMax { get; set; }
        [Column("QtdMinParcelas")]
        public int QtdMinParcelas { get; set; }
        [Column("QtdMaxParcelas")]
        public int QtdMaxParcelas { get; set; }

        public ICollection<Financiamento>? Financiamentos { get; set; }

        [NotMapped] 
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
