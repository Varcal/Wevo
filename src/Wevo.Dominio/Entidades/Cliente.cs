using System;
using Wevo.Dominio.Commands;
using Wevo.Dominio.Enums;
using Wevo.Dominio.ObjetosDeValor;
using Wevo.Dominio.Scopes;
using Wevo.NucleoCompartilhado.Base;

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


        public Cliente (ClienteRegistrar clienteRegistrar)
        {
            Nome = new Nome(clienteRegistrar.Nome);
            Cpf = new Cpf(clienteRegistrar.Cpf);
            Email = new Email(clienteRegistrar.Email);
            Telefone = new Telefone(clienteRegistrar.Telefone);
            Sexo = clienteRegistrar.Sexo;
            DataNascimento = clienteRegistrar.DataNascimento;
            ValidarCriacao();
        }

        internal void Alterar(ClienteAlterar clienteAlterar)
        {
            Nome = new Nome(clienteAlterar.Nome);
            Cpf = new Cpf(clienteAlterar.Cpf);
            Email = new Email(clienteAlterar.Email);
            Telefone = new Telefone(clienteAlterar.Telefone);
            Sexo = clienteAlterar.Sexo;
            DataNascimento = clienteAlterar.DataNascimento;
            ValidarAlteracao();
        }

        public bool ValidarCriacao()
        {
            return this.CriarSeEstiverValido();
        }

        public bool ValidarAlteracao()
        {
            return this.AlterarSeEstiverValido();
        }
    }
}
