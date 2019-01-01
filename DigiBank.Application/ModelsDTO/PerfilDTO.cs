using System.ComponentModel.DataAnnotations;

namespace DigiBank.Application.ModelsDTO
{
    public class PerfilDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Descricao { get; set; }
                
    }
}
