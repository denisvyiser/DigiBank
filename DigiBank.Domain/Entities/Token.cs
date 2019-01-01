using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiBank.Domain.Entities
{
    [Table("Token")]
    public partial class Token
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }

        [Required]
        [StringLength(710)]
        public string TokenKey { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataExpira { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}