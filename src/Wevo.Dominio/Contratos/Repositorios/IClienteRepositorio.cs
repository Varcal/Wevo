using System.Collections.Generic;
using Wevo.Dominio.Entidades;

namespace Wevo.Dominio.Contratos.Repositorios
{
    public interface IClienteRepositorio
    {
        void Inserir(Cliente cliente);
        void Alterar(Cliente cliente);
        void Excluir(Cliente cliente);
        IEnumerable<Cliente> SelecionarTodos(int indice, int numeroRegistros);
        Cliente ObterPorId(int id);
    }
}
