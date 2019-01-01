using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using DigiBank.Infra.Data.Context;

namespace DigiBank.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Response<Cliente> response, DigiBankContext context) : base(response, context)
        {
        }
    }
}
