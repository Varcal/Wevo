using System;
using Wevo.Dominio.Enums;

namespace Wevo.Dominio.Commands
{
    public class ClienteRegistrar
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email  { get; set; }
        public string Telefone { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
