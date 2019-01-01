using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigiBank.Application.ModelsDTO
{
    public class TransferenciaDTO
    {
        [Required]
        [StringLength(5)]
        public string ContaOrigem { get; set; }

        [Required]
        [StringLength(5)]
        public string ContaDestino { get; set; }

        public decimal Valor { get; set; }

       
    }
}
