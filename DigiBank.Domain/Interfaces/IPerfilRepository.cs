using DigiBank.Domain.Entities;
using DigiBank.Infra.CrossCutting.Utilities;

namespace DigiBank.Domain.Interfaces
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        Response<Perfil> GetAllByCliente(int ClienteId);
    }
}
