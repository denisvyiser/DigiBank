using AutoMapper;
using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;

namespace DigiBank.Application.Services
{
    public class TokenAppService : GenericAppService<Token, TokenDTO>, ITokenAppService
    {
        public TokenAppService(ITokenRepository repository, Response<TokenDTO> response, IMapper mapper) : base(repository, response, mapper)
        {
        }
    }
}
