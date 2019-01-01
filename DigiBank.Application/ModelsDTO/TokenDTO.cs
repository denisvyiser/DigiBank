using System;
using System.ComponentModel.DataAnnotations;

namespace DigiBank.Application.ModelsDTO
{
    public class TokenDTO
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        [Required]
        [StringLength(710)]
        public string TokenKey { get; set; }
                
        public DateTime DataExpira { get; set; }

        
    }
}