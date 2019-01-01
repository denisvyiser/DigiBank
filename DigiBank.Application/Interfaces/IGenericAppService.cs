using DigiBank.Infra.CrossCutting.Utilities;

namespace DigiBank.Application.Interfaces
{
    public interface IGenericAppService<T,K> where T : class where K : class
    {
        Response<K> Get(int id);
        //Response<K> GetBy(Expression<Func<K, bool>> predicate);
        Response<K> GetAll();
        Response<K> Insert(K obj);
        //Response<T> InsertList(IEnumerable<T> list);
        Response<K> Update(K obj);
        //Response<T> UpdateList(IEnumerable<T> list);

        Response<K> Delete(int id);
        Response<K> Delete(K obj);


    }
}
