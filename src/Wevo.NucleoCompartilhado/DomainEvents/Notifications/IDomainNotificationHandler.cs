using System.Collections.Generic;
using Wevo.NucleoCompartilhado.DomainEvents.Interfaces;

namespace Wevo.NucleoCompartilhado.DomainEvents.Notifications
{
    public interface IDomainNotificationHandler: IHandler<DomainNotification>
    {
        bool HasNotification();
        IEnumerable<DomainNotification> GetNotifications();
    }
}
