using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using DigiBank.Infra.Data.Context;

namespace DigiBank.Infra.Data.Repository
{
    public class ContaCorrenteRepository : Repository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(Response<ContaCorrente> response, DigiBankContext context) : base(response, context)
        {
        }
    }
}
