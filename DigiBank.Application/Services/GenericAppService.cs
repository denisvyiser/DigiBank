using AutoMapper;
using DigiBank.Application.Interfaces;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using System.Collections.Generic;

namespace DigiBank.Application.Services
{
    public class GenericAppService<T,K> : IGenericAppService<T,K> where K : class where T : class
    {

        private readonly IRepository<T> repository;
        private readonly IMapper mapper;
        private readonly Response<K> response;

        public GenericAppService(IRepository<T> repository, Response<K> response, IMapper mapper)
        {
            this.repository = repository;
            this.response = response;
            this.mapper = mapper;
        }

        public Response<K> Get(int id)
        {

            var repositoryResponse = repository.Get(id);

            response.Message = repositoryResponse.Message;
            response.Data = mapper.Map<K>(repositoryResponse.Data);
            response.Status = repositoryResponse.Status;
            
            return response;

        }

        public Response<K> GetAll()
        {
            var repositoryResponse = repository.GetAll();

            response.Message = repositoryResponse.Message;
            response.DataList = mapper.Map<IEnumerable<K>>(repositoryResponse.DataList);
            response.Status = repositoryResponse.Status;

            return response;

        }

        public Response<K> Insert(K obj)
        {
            var repositoryResponse = repository.Insert(mapper.Map<T>(obj));

            response.Message = repositoryResponse.Message;
            response.Data = mapper.Map<K>(repositoryResponse.Data);
            response.Status = repositoryResponse.Status;

            return response;
        }

        public Response<K> Update(K obj)
        {
            var repositoryResponse = repository.Update(mapper.Map<T>(obj));

            response.Message = repositoryResponse.Message;
            response.Data = mapper.Map<K>(repositoryResponse.Data);
            response.Status = repositoryResponse.Status;

            return response;
        }

        public Response<K> Delete(int id)
        {
            var repositoryResponse = repository.Delete(id);

            response.Message = repositoryResponse.Message;
            response.Data = mapper.Map<K>(repositoryResponse.Data);
            response.Status = repositoryResponse.Status;

            return response;
        }

        public Response<K> Delete(K obj)
        {
            var repositoryResponse = repository.Delete(mapper.Map<T>(obj));

            response.Message = repositoryResponse.Message;
            response.Data = mapper.Map<K>(repositoryResponse.Data);
            response.Status = repositoryResponse.Status;

            return response;
        }

    }
}
