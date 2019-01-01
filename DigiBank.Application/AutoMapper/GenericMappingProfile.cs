using AutoMapper;

namespace DigiBank.Application.AutoMapper
{
    public class GenericMappingProfile<T,K> : Profile where T : class where K : class
    {
        public GenericMappingProfile()
        {
            CreateMap<T, K>();
        }
    }
}
