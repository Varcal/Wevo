using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wevo.Dados.Mapeamentos;
using Wevo.Dominio.Entidades;

namespace Wevo.Dados.Contextos
{
    public sealed class EfContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Cliente> Clientes { get; set; }

        public EfContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
