
using DigiBank.Infra.CrossCutting.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DigiBank.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Response<T> Get(int id);
        Response<T> GetBy(Expression<Func<T, bool>> predicate);
        Response<T> GetAll();
        Response<T> Insert(T Entidade);
        Response<T> InsertList(IEnumerable<T> list);
        Response<T> Update(T Entidade);
        Response<T> UpdateList(IEnumerable<T> list);

        Response<T> Delete(int id);
        Response<T> Delete(T obj);
    }
}
