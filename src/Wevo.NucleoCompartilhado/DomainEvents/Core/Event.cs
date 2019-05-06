using System;

namespace Wevo.NucleoCompartilhado.DomainEvents.Core
{
    public class Event: DomainEvent
    {
        public DateTime DateOccurred { get; protected set; }

        public Event()
        {
            DateOccurred = DateTime.Now;
        }
    }
}
