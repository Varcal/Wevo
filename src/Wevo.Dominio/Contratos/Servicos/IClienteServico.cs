
using System.Collections.Generic;
using Wevo.Dominio.Commands;
using Wevo.Dominio.Entidades;

namespace Wevo.Dominio.Contratos.Servicos
{
    public interface IClienteServico
    {
        void Registrar(ClienteRegistrar clienteRegistrar);
        void Alterar(ClienteAlterar clienteAlterar);
        void Excluir(int clienteId);
        IReadOnlyCollection<Cliente> SelecionarTodos(int indice, int quantidade);
        Cliente ObterPorId(int id);
    }
}
