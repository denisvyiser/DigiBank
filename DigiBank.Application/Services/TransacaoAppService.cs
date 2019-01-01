using AutoMapper;
using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using System;

namespace DigiBank.Application.Services
{
    public class TransacaoAppService : GenericAppService<Transacao, TransacaoDTO>, ITransacaoAppService
    {
        public TransacaoAppService(ITransacaoRepository transacaoRepository, 
            Response<TransacaoDTO> response, IMapper mapper
            ) : base(transacaoRepository, response, mapper)
        {
            
        }

       
    }
}
