using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigiBank.Api.OperacaoBancaria.Controllers
{
    [ApiVersion("2.0")]
    [Authorize(Policy = "DigiBank")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OperacaoBancariaController : ControllerBase
    {
        private readonly IOperacaoBancariaAppService service;

        public OperacaoBancariaController(IOperacaoBancariaAppService service)
        {
            this.service = service;
        }


#if DEBUG
        [ApiExplorerSettings(IgnoreApi = false)]
#else
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [Authorize(Roles = "Cliente")]
        [HttpPost("Transferencia")]
        public virtual ActionResult<string> Transferencia([FromBody] TransferenciaDTO obj)
        {

            return Ok(service.Transferencia(obj).Message);

        }

    }


}


