using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiBank.Domain.Entities
{
    [Table("Transacao")]
    public partial class Transacao
    {
        [Key]
        public int Id { get; set; }

        public int ContaOrigem { get; set; }

        public int ContaDestino { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Valor { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoAutenticacao { get; set; }
      //  [DatePropertyValidationAttribute]
        public DateTime DataTransacao { get; set; }

        public virtual ContaCorrente ContaCorrenteOrigem { get; set; }

        public virtual ContaCorrente ContaCorrenteDestino { get; set; }
    }
}
