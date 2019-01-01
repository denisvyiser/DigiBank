using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigiBank.Api.Login.Controllers
{
    [ApiVersion("2.0")]
    [Authorize(Policy = "DigiBank")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService loginservice;
        public LoginController(ILoginAppService loginservice)
        {
            this.loginservice = loginservice;
        }
       
        [AllowAnonymous]
        [HttpPost("Logon")]
        public ActionResult<LoginTokenDTO> Logon([FromBody] LoginDTO login)
        {
            var response = loginservice.Login(login);
            return Ok(response.Data);
        }

       

    }
}
