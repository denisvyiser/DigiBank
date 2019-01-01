using AutoMapper;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;

namespace DigiBank.Application.AutoMapper
{
    class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<ClienteDTO, Cliente>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opts => opts.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Login, opts => opts.MapFrom(src => src.Login))
                .ForMember(dest => dest.Senha, opts => opts.MapFrom(src => src.Senha));
        }
    }
}
