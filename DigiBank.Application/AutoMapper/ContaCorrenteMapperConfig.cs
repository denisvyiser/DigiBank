using AutoMapper;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;

namespace DigiBank.Application.AutoMapper
{
    class ContaCorrenteMapperConfig : Profile
    {
        public ContaCorrenteMapperConfig()
        {
            CreateMap<ContaCorrenteDTO, ContaCorrente>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Numero, opts => opts.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Saldo, opts => opts.MapFrom(src => src.Saldo))
                .ForMember(dest => dest.ClienteId, opts => opts.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.DataCadastro, opts => opts.MapFrom(src => src.DataCadastro));
        }
    }
}