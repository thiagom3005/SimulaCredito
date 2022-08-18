using SimulaCredito.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulaCredito.Models
{
    [Table("Financiamento")]
    public class Financiamento: BaseEntity
    {
        [Column("ValorTotal")] 
        public double ValorTotal { get; set; }
        [Column("UltimoVencimento")]
        public DateTime UltimoVencimento { get; set; }
        [Column("ValorTotalJuros")]
        public double ValorTotalJuros { get; set; }
        [Column("TotalJuros")]
        public double TotalJuros { get; set; }

        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public long TipoFinanciamentoId { get; set; }
        public TipoFinanciamento TipoFinanciamento { get; set; }

        public ICollection<Parcela> parcelas { get; set; }
    }
}
