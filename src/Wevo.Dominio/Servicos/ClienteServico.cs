using System.Collections.Generic;
using System.Linq;
using Wevo.Dominio.Commands;
using Wevo.Dominio.Contratos.Repositorios;
using Wevo.Dominio.Contratos.Servicos;
using Wevo.Dominio.Contratos.Transacoes;
using Wevo.Dominio.Entidades;

namespace Wevo.Dominio.Servicos
{
    public sealed class ClienteServico: IClienteServico
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IUnitOfWork unitOfWork, IClienteRepositorio clienteRepositorio)
        {
            _unitOfWork = unitOfWork;
            _clienteRepositorio = clienteRepositorio;
        }

        public void Registrar(ClienteRegistrar clienteRegistrar)
        {
            var cliente = Cliente.CriarClienteParaRegistro(clienteRegistrar);
            _clienteRepositorio.Inserir(cliente);
            _unitOfWork.Save();
        }

        public void Alterar(ClienteAlterar clienteAlterar)
        {
            var cliente = _clienteRepositorio.ObterPorId(clienteAlterar.Id);
            cliente.Alterar(clienteAlterar);

            _clienteRepositorio.Alterar(cliente);
            _unitOfWork.Save();
        }

        public void Excluir(int clienteId)
        {
            var cliente = _clienteRepositorio.ObterPorId(clienteId);
            _clienteRepositorio.Excluir(cliente);
            _unitOfWork.Save();
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
