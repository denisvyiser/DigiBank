
using DigiBank.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigiBank.Application.Adapter
{
    [Authorize(Policy = "Digibank")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GenericController<T,K> : ControllerBase where T : class where K : class
    {

        private readonly IGenericAppService<T, K> service;

        public GenericController(IGenericAppService<T, K> service)
        {
            this.service = service;
        }


#if DEBUG
        [ApiExplorerSettings(IgnoreApi = false)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [Authorize(Roles = "Gerente")]
        [HttpGet]
        public virtual ActionResult<IEnumerable<K>> ListarTodos()
        {

            
            return Ok(service.GetAll().DataList);

        }

#if DEBUG
        [ApiExplorerSettings(IgnoreApi = false)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [Authorize(Roles = "Gerente")]
        [HttpGet("{id}")]
        public virtual ActionResult<K> Obter(int id)
        {
            

            return Ok(service.Get(id).Data);

        }

#if DEBUG
        [ApiExplorerSettings(IgnoreApi = false)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [Authorize(Roles = "Gerente")]
        [HttpPost]
        public virtual ActionResult<string> Cadastrar([FromBody] K obj)
        {

            return Ok(service.Insert(obj).Message);

        }

#if DEBUG
        [ApiExplorerSettings(IgnoreApi = false)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [Authorize(Roles = "Gerente")]
        [HttpPut("{id}")]
        public virtual ActionResult<string> Atualizar(long id, [FromBody] K obj)
        {

            return Ok(service.Update(obj).Message);
            

        }

#if DEBUG
        [ApiExplorerSettings(IgnoreApi = false)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [Authorize(Roles = "Gerente")]
        [HttpDelete("{id}")]
        public virtual ActionResult<string> Deletar(int id)
        {

            return Ok(service.Delete(id).Message);

        }
    }


}