using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using DigiBank.Infra.Data.Context;
using DigiBank.Infra.Data.RepositoryExtentios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DigiBank.Infra.Data.Repository
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private DigiBankContext context;
        private Response<T> response;
        public Repository(Response<T> response, DigiBankContext context)
        {
            this.context = context;
            this.response = response;
        }

        public virtual Response<T> Get(int id)
        {
            try
            {
                response.SetData(context.Set<T>().Find(id), true);
            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Consultar", false, ex);
            }

            return response;
        }

        public virtual Response<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                response.SetData(context.Set<T>().Where(predicate), true);
            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Consultar", false, ex);
            }

            return response;
        }

        public virtual Response<T> GetAll()
        {
            try
            {
                response.SetData(context.Set<T>().ToList(), true);
            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Consultar", false, ex);
            }

            return response;
        }

        public virtual Response<T> Insert(T obj)
        {
            try
            {

                var lambda = Extentions.LambdaInsertGeneration(obj);

                if (lambda != null)
                {
                    if (this.GetBy(lambda).DataList.Any())
                    {
                        response.SetMessage("Registro Já cadastrado", false);
                    }
                    else
                    {
                        context.Set<T>().Add(obj);
                        //context.Entry(obj).State = EntityState.Added;
                        context.SaveChanges();
                        response.SetData(obj, true);
                    }
                }

                else
                {
                    context.Set<T>().Add(obj);
                    context.SaveChanges();
                    response.SetData(obj, true);

                }

            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Cadastrar", false, ex);
            }

            return response;
        }

        public virtual Response<T> InsertList(IEnumerable<T> list)
        {
            try
            {
                context.Set<T>().AddRange(list);
                context.SaveChanges();

                response.SetData(list, true);
            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Cadastrar", false, ex);
            }

            return response;
        }

        public virtual Response<T> Update(T obj)
        {
            try
            {
                var lambda = Extentions.LambdaUpdateGeneration(obj);

                if (lambda != null)
                {
                    if (this.GetBy(lambda).DataList.Any())
                    {
                        response.SetMessage("Registro Já cadastrado", false);
                    }
                    else
                    {
                        context.Set<T>().Attach(obj);
                        context.Entry(obj).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                else
                {
                    context.Set<T>().Attach(obj);
                    context.Entry(obj).State = EntityState.Modified;
                    context.SaveChanges();
                }

                response.SetMessage("Dados Atualizados", true);
            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Atualizar", false, ex);
            }

            return response;
        }

        public virtual Response<T> UpdateList(IEnumerable<T> list)
        {
            try
            {
                context.Set<T>().UpdateRange(list.ToArray());
                context.SaveChanges();

                response.SetMessage("Dados Atualizados", true);
            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Atualizar", false, ex);
            }

            return response;
        }

        public virtual Response<T> Delete(int id)
        {
            try
            {
                T obj = context.Set<T>().Find(id);
                context.Set<T>().Remove(obj);
                context.SaveChanges();

                response.SetMessage("Dado Removido", true);
            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Remover Dado", false, ex);
            }

            return response;
        }

        public virtual Response<T> Delete(T obj)
        {
            try
            {
                context.Set<T>().Attach(obj);
                context.Set<T>().Remove(obj);
                context.SaveChanges();

                response.SetMessage("Dado Removido", true);
            }
            catch (Exception ex)
            {

                response.SetMessage("Erro ao Remover Dado", false, ex);
            }

            return response;
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}