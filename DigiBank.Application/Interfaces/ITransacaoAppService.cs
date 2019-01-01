using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using DigiBank.Infra.CrossCutting.Utilities;

namespace DigiBank.Application.Interfaces
{
    public interface ITransacaoAppService : IGenericAppService<Transacao, TransacaoDTO>
    {
        
    }
}
