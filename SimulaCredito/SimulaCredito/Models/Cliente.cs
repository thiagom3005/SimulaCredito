using SimulaCredito.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulaCredito.Models
{
    [Table("Cliente")]
    public class Cliente : BaseEntity
    {

        [Column("CPF")]
        public string CPF { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("UF")]
        public string UF { get; set; }
        [Column("Celular")]
        public double Celular { get; set; }
        [Column("Ativo")]
        public bool Ativo { get; set; }

        public ICollection<Financiamento>? Financiamentos { get; set; }
    }
}
