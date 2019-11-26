using System.Threading.Tasks;

namespace IndieVisible.Infra.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync(string email, string templateId, object templateData);
    }
}
