using System.Text.RegularExpressions;
using Wevo.Dominio.Entidades.Base;

namespace Wevo.Dominio.ObjetosDeValor
{
    public sealed class Telefone : ObjetoValor
    {
        public string Numero { get; private set; }


        private Telefone(){ }

        public Telefone(string numero)
        {
            Numero = numero;
        }

        public override string ToString()
        {
            return Numero;
        }

        private bool EstaValido(string numero)
        {
            var regex = @"^\([1-9]{2}\) [9]{0,1}[6-9]{1}[0-9]{3}\-[0-9]{4}$";

            return Regex.IsMatch(numero, regex);
        }
    }
}
