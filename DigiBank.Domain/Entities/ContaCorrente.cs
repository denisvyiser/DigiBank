using DigiBank.Domain.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiBank.Domain.Entities
{
    [Table("ContaCorrente")]
    public partial class ContaCorrente
    {
        public ContaCorrente()
        {
            TransacaoContaOrigem = new HashSet<Transacao>();
            TransacaoContaDestino = new HashSet<Transacao>();
        }

        [Key]
        public int Id { get; set; }

        [PropertyValidation]
        [Required]
        [StringLength(8)]
        public string Numero { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Saldo { get; set; }

        //[DatePropertyValidationAttribute]
        public DateTime DataCadastro { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Transacao> TransacaoContaOrigem { get; set; }

        public virtual ICollection<Transacao> TransacaoContaDestino { get; set; }
    }
}
