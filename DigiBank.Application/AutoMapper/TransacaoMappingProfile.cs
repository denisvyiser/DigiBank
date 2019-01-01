using AutoMapper;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;

namespace DigiBank.Application.AutoMapper
{
    public class TransacaoMappingProfile : Profile
    {
        public TransacaoMappingProfile()
        {
            CreateMap<Transacao, TransacaoDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.ContaOrigem, opts => opts.MapFrom(src => src.ContaOrigem))
                .ForMember(dest => dest.ContaDestino, opts => opts.MapFrom(src => src.ContaDestino))
                .ForMember(dest => dest.Valor, opts => opts.MapFrom(src => src.Valor))
                .ForMember(dest => dest.CodigoAutenticacao, opts => opts.MapFrom(src => src.CodigoAutenticacao))
                .ForMember(dest => dest.DataTransacao, opts => opts.MapFrom(src => src.CodigoAutenticacao));
                
        }
    }
}
