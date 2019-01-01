using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;


namespace DigiBank.Infra.CrossCutting.Identity.Authorization
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        private readonly IConfiguration _configuration;

        public SigningConfigurations(IConfiguration _configuration)
        {


            this._configuration = _configuration;

            string dirCertificado = _configuration.GetSection("CertificateDirectory").Value;

            using (var cert = new X509Certificate2(dirCertificado, "12345"))
            {
                Key = new RsaSecurityKey(cert.GetRSAPrivateKey());
            }


            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
