using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigiBank.Api.Transacao.Controllers
{
    [ApiVersion("2.0")]
    [Authorize(Policy = "DigiBank")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoAppService service;

        public TransacaoController(ITransacaoAppService service)
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
        public virtual ActionResult<IEnumerable<TransacaoDTO>> ListarTodos()
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
        public virtual ActionResult<ContaCorrenteDTO> Obter(int id)
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
        public virtual ActionResult<string> Cadastrar([FromBody] TransacaoDTO obj)
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
        public virtual ActionResult<string> Atualizar(long id, [FromBody] TransacaoDTO obj)
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