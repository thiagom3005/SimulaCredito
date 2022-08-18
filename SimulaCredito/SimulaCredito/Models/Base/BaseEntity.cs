using System.ComponentModel.DataAnnotations.Schema;

namespace SimulaCredito.Models.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public long Id { get; set; }
    }
}
