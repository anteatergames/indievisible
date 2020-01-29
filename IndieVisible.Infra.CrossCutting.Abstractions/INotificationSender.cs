using System.Threading.Tasks;

namespace IndieVisible.Infra.CrossCutting.Abstractions
{
    public interface INotificationSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync(string email, string templateId, object templateData);

        Task SendTeamNotificationAsync(string message);
    }
}