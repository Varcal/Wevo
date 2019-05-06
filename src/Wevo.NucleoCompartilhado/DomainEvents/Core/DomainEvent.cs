using System;
using Wevo.NucleoCompartilhado.DomainEvents.Interfaces;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.NucleoCompartilhado.DomainEvents.Core
{
    public abstract class DomainEvent
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public string EventType { get; protected set; }

        protected DomainEvent()
        {
            EventType = GetType().Name;
        }

        public static void RaiseEvent<T>(T @event) where T : Event
        {
            if(ServiceProvider == null) return;
            
            var obj = ServiceProvider.GetService(
                @event.EventType.Equals(nameof(DomainNotification)) 
                ? typeof(IDomainNotificationHandler) 
                : typeof(IHandler<T>));
            
            ((IHandler<T>)obj).Handle(@event);
        }
    }
}
