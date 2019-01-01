using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using DigiBank.Infra.Data.Context;

namespace DigiBank.Infra.Data.Repository
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        public TokenRepository(Response<Token> response, DigiBankContext context) : base(response, context)
        {
        }
    }
}
