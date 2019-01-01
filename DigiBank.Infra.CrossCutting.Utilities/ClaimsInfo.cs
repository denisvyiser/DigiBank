using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;


namespace DigiBank.Infra.CrossCutting.Utilities
{
    public static class ClaimsInfo
    {
        public static string GetClaimInfo(string Token, string chave)
        {
            if (Token.Length > 0 && chave.Length > 0)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = (JwtSecurityToken)tokenHandler.ReadToken(Token);
                return token.Claims.FirstOrDefault(t => t.Type == chave).Value;
            }
            else
            {
                return String.Format("Token: {0} e chave: {1} precisam ter um valor", Token, chave);
            }

        }
    }
}

