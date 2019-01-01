using AutoMapper;
using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;

namespace DigiBank.Application.Services
{
    public class ContaCorrenteAppService : GenericAppService<ContaCorrente, ContaCorrenteDTO>, IContaCorrenteAppService
    {
        public ContaCorrenteAppService(IContaCorrenteRepository repository, Response<ContaCorrenteDTO> response, IMapper mapper) : base(repository, response, mapper)
        {
        }
    }
}
