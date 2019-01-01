using AutoMapper;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;

namespace DigiBank.Application.AutoMapper
{
    class PerfilMapperConfig : Profile
    {
        public PerfilMapperConfig()
        {
            CreateMap<PerfilDTO, Perfil>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opts => opts.MapFrom(src => src.Descricao));
        }
    }
}
