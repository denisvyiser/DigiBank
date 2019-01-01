using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Identity.Authorization;
using DigiBank.Infra.CrossCutting.Utilities;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using DigiBank.Application.IdentitySecurity;
using System.IdentityModel.Tokens.Jwt;
using DigiBank.Domain.Entities;

namespace DigiBank.Application.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly Response<LoginTokenDTO> response;
        private readonly IClienteRepository clienteRepository;
        private readonly ITokenRepository tokenRepository;
        private readonly IPerfilRepository perfilRepository;
        private readonly IConfiguration configuration;
        private readonly SigningConfigurations signingConfigurations;

        public LoginAppService(Response<LoginTokenDTO> response, IClienteRepository clienteRepository,
            ITokenRepository tokenRepository, IPerfilRepository perfilRepository,
            IConfiguration configuration, SigningConfigurations signingConfigurations)
        {
            this.response = response;
            this.clienteRepository = clienteRepository;
            this.tokenRepository = tokenRepository;
            this.perfilRepository = perfilRepository;
            this.configuration = configuration;
            this.signingConfigurations = signingConfigurations;
            
        }

        public Response<LoginTokenDTO> Login(LoginDTO login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.Login) || string.IsNullOrEmpty(login.Senha))
                {
                    response.SetMessage("Login e Senha não podem ser valores nulos", false);
                    return response;
                }

                string senha = DataEncryption.Encrypt(login.Senha);

                var cliente = clienteRepository.GetBy(c => c.Login == login.Login && c.Senha == senha).DataList.FirstOrDefault();


                if (cliente == null)
                {
                    response.SetMessage("Token Não Foi Gerador -> Dados Inválidos!", false);
                    return response;
                }

                var tokenAtual = tokenRepository.GetBy(c => c.ClienteId == cliente.Id).DataList.FirstOrDefault();

                var perfis = perfilRepository.GetAllByCliente(cliente.Id).DataList.ToList();

                var tokenConfiguration = new TokenConfigurations();

               
                tokenConfiguration.Audience = configuration.GetSection("TokenConfigurations:Audience").Value;
                tokenConfiguration.Issuer = configuration.GetSection("TokenConfigurations:Issuer").Value;
                tokenConfiguration.Seconds = Convert.ToInt32(configuration.GetSection("TokenConfigurations:Seconds").Value);


                var claimsResponse = TokenGenerator.ClaimsDados(cliente, perfis);

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(tokenConfiguration.Seconds);

                var securityToken = TokenGenerator.TokenKey(tokenConfiguration.Issuer, tokenConfiguration.Audience, signingConfigurations.SigningCredentials, claimsResponse, dataCriacao, dataExpiracao);

                var tokenKey = new JwtSecurityTokenHandler().WriteToken(securityToken);

                if(tokenAtual==null)
                {
                    Token token = new Token();

                    token.ClienteId = cliente.Id;
                    token.TokenKey = tokenKey;
                    token.DataCriacao = dataCriacao;
                    token.DataExpira = dataExpiracao;

                    var insertToken = tokenRepository.Insert(token);

                  if (insertToken.Status)
                    {
                        response.SetData(new LoginTokenDTO() { TokenKey = tokenKey, DataExpira = dataExpiracao }, true);
                    }
                  else
                    {
                        response.SetMessage(insertToken.Message, insertToken.Status, insertToken.Ex);

                    }
                }
                else
                {
                    tokenAtual.DataCriacao = dataCriacao;
                    tokenAtual.DataExpira = dataExpiracao;
                    tokenAtual.TokenKey = tokenKey;

                    var updateToken = tokenRepository.Update(tokenAtual);

                    if (updateToken.Status)
                    {
                        response.SetData(new LoginTokenDTO() { TokenKey = tokenKey, DataExpira = dataExpiracao }, true);
                    }

                    else
                    {
                        response.SetMessage(updateToken.Message, updateToken.Status, updateToken.Ex);

                    }


                }

            }
            catch(Exception ex)
            {
                response.SetMessage("Erro ao gerar Token", false, ex);
            }

            return response;
        }
    }
}
