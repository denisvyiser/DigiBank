using Microsoft.AspNetCore.Http;


namespace DigiBank.Infra.CrossCutting.Utilities
{
    public class TokenContextAccessor
    {
        private readonly IHttpContextAccessor acessor;
        public TokenContextAccessor(IHttpContextAccessor acessor)
        {
            this.acessor = acessor;
        }

        public string GetToken()
        {
            return acessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
        }
    }
}
