using AutoMapper;
using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;


namespace DigiBank.Application.Services
{
    public class ClienteAppService : GenericAppService<Cliente, ClienteDTO>, IClienteAppService
    {
        public ClienteAppService(IClienteRepository repository, Response<ClienteDTO> response, IMapper mapper) : base(repository, response, mapper)
        {
        }
    }
}
