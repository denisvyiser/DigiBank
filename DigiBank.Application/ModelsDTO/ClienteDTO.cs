using System.ComponentModel.DataAnnotations;

namespace DigiBank.Application.ModelsDTO
{
    public class ClienteDTO
    {
      
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Nome { get; set; }
            
            [Required]
            [StringLength(10)]
            public string Login { get; set; }

            [Required]
            [StringLength(8)]
            public string Senha { get; set; }

          }
    }
