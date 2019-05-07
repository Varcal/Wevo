using System.Collections.Generic;
using System.Linq;
using Wevo.Dominio.Commands;
using Wevo.Dominio.Contratos.Repositorios;
using Wevo.Dominio.Contratos.Servicos;
using Wevo.Dominio.Contratos.Transacoes;
using Wevo.Dominio.Entidades;

namespace Wevo.Dominio.Servicos
{
    public sealed class ClienteServico:ServicoBase, IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IUnitOfWork unitOfWork,IClienteRepositorio clienteRepositorio)
            :base(unitOfWork)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Registrar(ClienteRegistrar clienteRegistrar)
        {
            var cliente = new Cliente(clienteRegistrar);
            _clienteRepositorio.Inserir(cliente);
            Save();
        }

        public void Alterar(ClienteAlterar clienteAlterar)
        {
            var cliente = _clienteRepositorio.ObterPorId(clienteAlterar.Id);
            cliente.Alterar(clienteAlterar);

            _clienteRepositorio.Alterar(cliente);
            Save();
        }

        public void Excluir(int clienteId)
        {
            var cliente = _clienteRepositorio.ObterPorId(clienteId);
            _clienteRepositorio.Excluir(cliente);
            Save();
        }

        public IReadOnlyCollection<Cliente> SelecionarTodos(int indice, int quantidade)
        {
            return _clienteRepositorio.SelecionarTodos(indice, quantidade).ToList();
        }

        public Cliente ObterPorId(int id)
        {
            return _clienteRepositorio.ObterPorId(id);
        }
    }
}
