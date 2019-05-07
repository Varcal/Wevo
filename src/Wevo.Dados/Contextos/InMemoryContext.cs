using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Wevo.Dados.Mapeamentos;
using Wevo.Dominio.Entidades;

namespace Wevo.Dados.Contextos
{
    public sealed class InMemoryContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public InMemoryContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("WevoMemoryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
