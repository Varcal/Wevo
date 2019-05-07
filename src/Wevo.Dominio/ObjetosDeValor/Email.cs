using System.Text.RegularExpressions;
using Wevo.NucleoCompartilhado.Base;
using Wevo.NucleoCompartilhado.DomainEvents.Core;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.Dominio.ObjetosDeValor
{
    public sealed class Email : ObjetoValor
    {
        public string Endereco { get; private set; }


        private Email() { }

        public Email(string endereco)
        {
            if (!EstaValido(endereco))
            {
                DomainEvent.RaiseEvent(new DomainNotification("EmailInvalido", "Endereço de e-mail inválido"));
                return;
            }

            Endereco = endereco;
        }

        public override string ToString()
        {
            return Endereco;
        }

        private bool EstaValido(string endereco)
        {
            var regex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            return Regex.IsMatch(endereco,regex);
        }
    }
}
