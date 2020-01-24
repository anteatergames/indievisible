using IndieVisible.Infra.CrossCutting.Abstractions;
using System.Threading.Tasks;

namespace IndieVisible.Infra.CrossCutting.Identity.Services
{
    public class DefaultNotificationSender : INotificationSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }

        public Task SendEmailAsync(string email, string templateId, object templateData)
        {
            return Task.CompletedTask;
        }

        public Task SendTeamNotificationAsync(string message)
        {
            return Task.CompletedTask;
        }
    }
}