using System;
using System.Linq;
using System.Text.RegularExpressions;
using Wevo.Dominio.Entidades.Base;

namespace Wevo.Dominio.ObjetosDeValor
{
    public sealed class Email : ObjetoValor
    {
        public string Endereco { get; private set; }


        private Email() { }

        public Email(string endereco)
        {
            if(!EstaValido(endereco))
                throw new ApplicationException("Endereço de e-mail inválido");

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
