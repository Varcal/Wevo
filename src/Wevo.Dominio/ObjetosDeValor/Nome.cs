using System;
using Wevo.Dominio.Entidades.Base;

namespace Wevo.Dominio.ObjetosDeValor
{
    public sealed class Nome: ObjetoValor
    {
        public string Texto { get; private set; }

        private  Nome() { }

        public Nome(string texto)
        {
            if(texto.Length > 100)
                throw new ApplicationException(@"Nome deve conter no máximo 100 caracteres.");

            Texto = texto;
        }

        public override string ToString()
        {
            return Texto;
        }     
    }
}
