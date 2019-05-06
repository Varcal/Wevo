using System;
using Wevo.NucleoCompartilhado.DomainEvents.Core;

namespace Wevo.NucleoCompartilhado.DomainEvents.Interfaces
{
    public interface IHandler<in T>: IDisposable where T: Event
    {
        void Handle(T @event);
    }
}
