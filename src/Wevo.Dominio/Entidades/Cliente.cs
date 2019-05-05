using System;
using Wevo.Dominio.Commands;
using Wevo.Dominio.Entidades.Base;
using Wevo.Dominio.Enums;
using Wevo.Dominio.ObjetosDeValor;

namespace Wevo.Dominio.Entidades
{
    public sealed class Cliente : Entidade
    {
        public Nome Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public Sexo Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }

        private Cliente() { }


        public static Cliente CriarClienteParaRegistro(ClienteRegistrar clienteRegistrar)
        {
            return new Cliente()
            {
                Nome = new Nome(clienteRegistrar.Nome),
                Cpf = new Cpf(clienteRegistrar.Cpf),
                Email = new Email(clienteRegistrar.Email),
                Telefone = new Telefone(clienteRegistrar.Telefone),
                Sexo = clienteRegistrar.Sexo,
                DataNascimento = clienteRegistrar.DataNascimento
            };
        }

        internal void Alterar(ClienteAlterar clienteAlterar)
        {
            Nome = new Nome(clienteAlterar.Nome);
            Cpf = new Cpf(clienteAlterar.Cpf);
            Email = new Email(clienteAlterar.Email);
            Telefone = new Telefone(clienteAlterar.Telefone);
            Sexo = clienteAlterar.Sexo;
            DataNascimento = clienteAlterar.DataNascimento;
        }
    }
}
