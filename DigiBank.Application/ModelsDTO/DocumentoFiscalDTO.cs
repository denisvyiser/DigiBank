using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigiBank.Application.ModelsDTO
{
    public class DocumentoFiscalDTO
    {
        [Required]
        [StringLength(5)]
        public string ContaOrigem { get; set; }

        public string ClieneNomeOrigem { get; set; }

        [Required]
        [StringLength(5)]
        public string ContaDestino { get; set; }

        public string ClieneNomeDestino { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataOperacao { get; set; }

        public string CodigoAutenticacao { get; set; }


    }
}
