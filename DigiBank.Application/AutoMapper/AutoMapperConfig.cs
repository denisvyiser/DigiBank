using AutoMapper;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;

namespace DigiBank.Application.AutoMapper
{
        public class AutoMapperConfig
        {
            public static MapperConfiguration RegisterMappings()
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ClienteMappingProfile());
                    cfg.AddProfile(new ContaCorrenteMapperConfig());
                    cfg.AddProfile(new PerfilMapperConfig());
                    cfg.AddProfile(new TokenMapperConfig());
                    cfg.AddProfile(new TransacaoMappingProfile());
                    cfg.AddProfile(new GenericMappingProfile<Cliente, ClienteDTO>());
                    cfg.AddProfile(new GenericMappingProfile<ContaCorrente, ContaCorrenteDTO>());
                    cfg.AddProfile(new GenericMappingProfile<Perfil, PerfilDTO>());
                    cfg.AddProfile(new GenericMappingProfile<Token, TokenDTO>());
                    cfg.AddProfile(new GenericMappingProfile<Transacao, TransacaoDTO>());
                });
            }
        }
    }

