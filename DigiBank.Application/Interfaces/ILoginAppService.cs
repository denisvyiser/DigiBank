using DigiBank.Application.ModelsDTO;
using DigiBank.Infra.CrossCutting.Utilities;

namespace DigiBank.Application.Interfaces
{
    public interface ILoginAppService
    {
        Response<LoginTokenDTO> Login(LoginDTO login);
    }
}
