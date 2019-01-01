using DigiBank.Domain.Entities;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Utilities;
using DigiBank.Infra.Data.Context;
using System;
using System.Linq;


namespace DigiBank.Infra.Data.Repository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        private readonly Response<Perfil> response;
        private readonly DigiBankContext context;
        public PerfilRepository(Response<Perfil> response, DigiBankContext context) : base(response, context)
        {
            this.response = response;
            this.context = context;
        }

        public Response<Perfil> GetAllByCliente(int ClienteId)
        {
          
            try
            {
                
                

                response.SetData(context.ClientePerfil.Where(c => c.ClienteId == ClienteId).Select(c => new Perfil { Id = c.Perfil.Id, Descricao = c.Perfil.Descricao }), true);
            }
            catch (Exception ex)
            {
                response.SetMessage("Erro ao Consultar", false, ex);
            }

            return response;
        }
    
    }
}
