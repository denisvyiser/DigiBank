using DigiBank.Application.ModelsDTO;
using DigiBank.Infra.CrossCutting.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBank.Application.Interfaces
{
    public interface IOperacaoBancariaAppService
    {
        Response<DocumentoFiscalDTO> Transferencia(TransferenciaDTO obj);
    }
}
