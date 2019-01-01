using DigiBank.Domain.CustomDataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiBank.Domain.Entities
{
    [Table("ClientePerfil")]
    public partial class ClientePerfil
    {
        [Key]
        public int Id { get; set; }

        [PropertyValidation]
        public int ClienteId { get; set; }

        [PropertyValidation]
        public int PerfilId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}
