using System.ComponentModel.DataAnnotations;

namespace DigiBank.Application.ModelsDTO
{
    public class LoginDTO
    {
        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [StringLength(8)]
        public string Senha { get; set; }
    }
}
