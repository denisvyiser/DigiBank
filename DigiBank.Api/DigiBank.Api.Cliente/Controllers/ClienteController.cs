using DigiBank.Application.Adapter;
using DigiBank.Application.Interfaces;
using DigiBank.Application.ModelsDTO;
using DigiBank.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DigiBank.Api.Cliente.Controllers
{
    [ApiVersion("2.0")]
    public class ClienteController : GenericController<DigiBank.Domain.Entities.Cliente, ClienteDTO>
    {
        public ClienteController(IClienteAppService service) : base(service)
        {
        }
    }


}