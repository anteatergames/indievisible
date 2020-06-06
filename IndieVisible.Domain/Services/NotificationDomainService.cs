using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;

namespace IndieVisible.Domain.Services
{
    public class NotificationDomainService : BaseDomainMongoService<Notification, INotificationRepository>, INotificationDomainService
    {
        public NotificationDomainService(INotificationRepository repository) : base(repository)
        {
        }
    }
}