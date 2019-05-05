using System;
using System.Collections.Generic;
using System.Linq;
using Wevo.Dados.Contextos;
using Wevo.Dominio.Contratos.Repositorios;
using Wevo.Dominio.Entidades;

namespace Wevo.Dados.Repositorios
{
    public sealed class ClienteRepositorio: IClienteRepositorio
    {
        private readonly EfContext _efContext;

        public ClienteRepositorio(EfContext efContext)
        {
            _efContext = efContext;
        }

        public void Inserir(Cliente cliente)
        {
            _efContext.Clientes.Add(cliente);
;        }

        public void Alterar(Cliente cliente)
        {
            _efContext.Clientes.Update(cliente);
        }

        public void Excluir(Cliente cliente)
        {
            _efContext.Clientes.Remove(cliente);
        }

        public IEnumerable<Cliente> SelecionarTodos(int indice, int quantidadeRegistros)
        {
            var clientes = _efContext.Clientes;

            if (indice == 0 && quantidadeRegistros == 0)
                return clientes.ToList();

            return clientes
                .Skip(indice).Take(quantidadeRegistros).ToList();
        }

        public Cliente ObterPorId(int id)
        {
            return _efContext.Clientes.Find(id);
        }
    }
}
