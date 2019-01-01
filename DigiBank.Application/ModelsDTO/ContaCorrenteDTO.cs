
using System;
using System.ComponentModel.DataAnnotations;

namespace DigiBank.Application.ModelsDTO
{
    
    public class ContaCorrenteDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Numero { get; set; }

        public decimal Saldo { get; set; }

        public int ClienteId { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
