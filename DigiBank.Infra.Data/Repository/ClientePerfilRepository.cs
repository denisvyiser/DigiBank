using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using DigiBank.Infra.Data.Context;

namespace DigiBank.Infra.Data.Repository
{
    public class ClientePerfilRepository : Repository<ClientePerfil>, IClientePerfilRepository
    {
        public ClientePerfilRepository(Response<ClientePerfil> response, DigiBankContext context) : base(response, context)
        {
        }
    }
}

