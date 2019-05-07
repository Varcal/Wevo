using System.Text.RegularExpressions;
using Wevo.NucleoCompartilhado.Base;
using Wevo.NucleoCompartilhado.DomainEvents.Core;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.Dominio.ObjetosDeValor
{
    public sealed class Telefone : ObjetoValor
    {
        public string Numero { get; private set; }


        private Telefone(){ }

        public Telefone(string numero)
        {
            if (!EstaValido(numero))
            {
                DomainEvent.RaiseEvent(new DomainNotification("TelefoneInvalido", "Número de telefone inválido"));
                return;
            }

            Numero = numero;
        }

        public override string ToString()
        {
            return Numero;
        }

        private bool EstaValido(string numero)
        {
            var regexTelefone = @"^[0-9]{10}$";
            var regexCelular = @"^[0-9]{11}$";
            return Regex.IsMatch(numero, regexTelefone) || Regex.IsMatch(numero, regexCelular);
        }
    }
}
