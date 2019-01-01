using DigiBank.Domain.CustomDataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiBank.Domain.Entities
{
    [Table("Perfil")]
    public partial class Perfil
    {
        public Perfil()
        {
            ClientePerfil = new HashSet<ClientePerfil>();

        }

        [Key]
        public int Id { get; set; }

        [PropertyValidation]
        [Required]
        [StringLength(10)]
        public string Descricao { get; set; }

        public virtual ICollection<ClientePerfil> ClientePerfil { get; set; }
    }
}
