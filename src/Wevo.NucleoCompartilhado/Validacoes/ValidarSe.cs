using System;
using System.Text.RegularExpressions;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.NucleoCompartilhado.Validacoes
{
    public partial class ValidarSe
    {
        public static DomainNotification NaoEstaVazio(Guid guid, string mensagem)
        {
            return guid == Guid.Empty ? new DomainNotification("GarantirQueNaoEstaVazio", mensagem) : null;
        }

        public static DomainNotification NaoEstaNulo(object objeto, string mensagem)
        {
            return objeto == null ? new DomainNotification("GarantirQueNaoEstaNulo", mensagem) : null;
        }

        public static DomainNotification EstaNulo(object objeto, string mensagem)
        {
            return objeto != null ? new DomainNotification("GarantirQueEstaNulo", mensagem) : null;
        }

        public static DomainNotification Verdadeiro(bool valor, string menssagem)
        {
            return !valor ? new DomainNotification("GarantirQueVerdadeiro", menssagem) : null;
        }
    }
}
