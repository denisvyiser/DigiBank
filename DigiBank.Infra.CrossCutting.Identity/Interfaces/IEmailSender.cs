using System.Threading.Tasks;

namespace DigiBank.Infra.CrossCutting.Identity.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
