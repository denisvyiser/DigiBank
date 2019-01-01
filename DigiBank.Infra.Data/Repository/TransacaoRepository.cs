using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using DigiBank.Infra.Data.Context;

namespace DigiBank.Infra.Data.Repository
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(Response<Transacao> response, DigiBankContext context) : base(response, context)
        {
        }
    }
}
