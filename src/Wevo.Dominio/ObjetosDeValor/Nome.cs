using Wevo.NucleoCompartilhado.Base;
using Wevo.NucleoCompartilhado.DomainEvents.Core;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.Dominio.ObjetosDeValor
{
    public sealed class Nome: ObjetoValor
    {
        public string Texto { get; private set; }

        private  Nome() { }

        public Nome(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                DomainEvent.RaiseEvent(new DomainNotification("NomeInvalido", "Nome é obrigatório"));
                return;
            }
                

            Texto = texto;
        }

        public override string ToString()
        {
            return Texto;
        }     
    }
}
