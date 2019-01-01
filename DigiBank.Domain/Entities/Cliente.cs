using DigiBank.Domain.CustomDataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiBank.Domain.Entities
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            ClientePerfil = new HashSet<ClientePerfil>();
            ContaCorrente = new HashSet<ContaCorrente>();
            Token = new HashSet<Token>();

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [PropertyValidation]
        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [StringLength(8)]
        public string Senha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientePerfil> ClientePerfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContaCorrente> ContaCorrente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Token> Token { get; set; }
    }
}
