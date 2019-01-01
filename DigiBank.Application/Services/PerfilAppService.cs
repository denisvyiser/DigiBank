using AutoMapper;
using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;

namespace DigiBank.Application.Services
{
    public class PerfilAppService : GenericAppService<Perfil, PerfilDTO>, IPerfilAppService
    {
        public PerfilAppService(IPerfilRepository repository, Response<PerfilDTO> response, IMapper mapper) : base(repository, response, mapper)
        {
        }
    }
}
