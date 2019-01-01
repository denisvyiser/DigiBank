using AutoMapper;
using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;

namespace DigiBank.Application.Services
{
    public class ClientePerfilAppService : GenericAppService<ClientePerfil, ClientePerfilDTO>, IClientePerfilAppService
    {
        public ClientePerfilAppService(IClientePerfilRepository repository, Response<ClientePerfilDTO> response, IMapper mapper) : base(repository, response, mapper)
        {
        }
    }
}