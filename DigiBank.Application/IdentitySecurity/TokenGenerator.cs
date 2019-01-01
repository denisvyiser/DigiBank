using DigiBank.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace DigiBank.Application.IdentitySecurity
{
    public class TokenGenerator
    {
        public static ClaimsIdentity ClaimsDados(Cliente cliente, List<Perfil> perfis)
        {
            
            List<Claim> ListClaims = new List<Claim>();
            ClaimsIdentity identity = null;
            
                ListClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")));
                ListClaims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, cliente.Login));
                ListClaims.Add(new Claim("ClienteId", cliente.Id.ToString()));

                string listaPerfis = "";
                foreach (var roles in perfis)
                {
                    ListClaims.Add(new Claim(ClaimTypes.Role, roles.Descricao.ToString().Trim()));

                    listaPerfis += roles.Descricao.ToString().Trim() + ";";
                }

                identity = new ClaimsIdentity
                (
                    new GenericIdentity(cliente.Login, "Login"),
                    ListClaims
                );

         
            return identity;
        }

        public static SecurityToken TokenKey(string issuer, string audience, SigningCredentials signingCredentials, ClaimsIdentity identity, DateTime? dataCriacao, DateTime? dataExpiracao)
        {

            var handler = new JwtSecurityTokenHandler();


            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao,
            });

            return securityToken;
        }

        public static string FuncionalidadesString(List<Perfil> perfis)
        {
            string listaFuncionalidades = "";

            foreach (var roles in perfis)
            {
                listaFuncionalidades += roles.Descricao.ToString().Trim() + ";";
            }

            return listaFuncionalidades;
        }


    }
}
