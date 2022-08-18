using SimulaCredito.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulaCredito.Models
{
    [Table("Parcela")]
    public class Parcela : BaseEntity
    {
        [Column("NumeroParcela")] 
        public int NumeroParcela { get; set; }
        [Column("Valor")]
        public double Valor { get; set; }
        [Column("DataVencimento")]
        public DateTime DataVencimento { get; set; }
        [Column("DataPagamento")]
        public DateTime DataPagamento { get; set; }

        public long FinanciamentoId { get; set; }
        public Financiamento financiamento { get; set; }

    }
}
