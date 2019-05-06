
using System;
using Wevo.NucleoCompartilhado.Base;
using Wevo.NucleoCompartilhado.DomainEvents.Core;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.Dominio.ObjetosDeValor
{
    public sealed class Cpf : ObjetoValor
    {
        public string Numero { get; private set; }


        private Cpf(){}

        public Cpf(string numero)
        {
            if (!Validar(numero))
            {
                DomainEvent.RaiseEvent(new DomainNotification("CpfInvalido", "CPF informado não é válido"));
                return;
            }

            Numero = numero;
        }

        public override string ToString()
        {
            return Numero;
        }

        private bool Validar(string cpf)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();

            tempCpf = tempCpf + digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto;

            return cpf.EndsWith(digito);
        }
    }
}
