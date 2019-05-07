using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wevo.Dados.Contextos;
using Wevo.Dominio.Contratos.Repositorios;
using Wevo.Dominio.Entidades;

namespace Wevo.Dados.Repositorios
{
    public class ClienteRepositoryInMemory: IClienteRepositorio
    {
        private readonly InMemoryContext _db;

        public ClienteRepositoryInMemory(InMemoryContext db)
        {
            _db = db;
        }

        public void Inserir(Cliente cliente)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();

        }

        public void Alterar(Cliente cliente)
        {
            _db.Clientes.Update(cliente);
            _db.SaveChanges();
        }

        public void Excluir(Cliente cliente)
        {
            _db.Clientes.Remove(cliente);
            _db.SaveChanges();
        }

        public IEnumerable<Cliente> SelecionarTodos(int indice, int quantidadeRegistros)
        {
            var clientes = _db.Clientes;

            if (indice == 0 && quantidadeRegistros == 0)
                return clientes.ToList();

            return clientes
                .Skip(indice).Take(quantidadeRegistros).ToList();
        }

        public Cliente ObterPorId(int id)
        {
            return _db.Clientes.Find(id);
        }
    }
}
