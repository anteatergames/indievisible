using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class NotificationDomainService : BaseDomainMongoService<Notification, INotificationRepository>, INotificationDomainService
    {
        public NotificationDomainService(INotificationRepository repository) : base(repository)
        {
        }
    }
}
