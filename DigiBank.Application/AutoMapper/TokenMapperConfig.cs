using AutoMapper;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;

namespace DigiBank.Application.AutoMapper
{
    class TokenMapperConfig : Profile
    {
        public TokenMapperConfig()
        {
            CreateMap<TokenDTO, Token>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.ClienteId, opts => opts.MapFrom(src => src.ClienteId))
               .ForMember(dest => dest.TokenKey, opts => opts.MapFrom(src => src.TokenKey))
               .ForMember(dest => dest.DataExpira, opts => opts.MapFrom(src => src.DataExpira));
        }
    }
}
