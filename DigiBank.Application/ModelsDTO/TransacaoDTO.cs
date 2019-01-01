using System;
using System.ComponentModel.DataAnnotations;

namespace DigiBank.Application.ModelsDTO
{
    public class TransacaoDTO
    {
        public int Id { get; set; }

        public int ContaOrigem { get; set; }

        public int ContaDestino { get; set; }

        public decimal Valor { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoAutenticacao { get; set; }

        public DateTime DataTransacao { get; set; }

    }
}
