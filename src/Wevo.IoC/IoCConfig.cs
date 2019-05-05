using Microsoft.Extensions.DependencyInjection;
using Wevo.Dados.Contextos;
using Wevo.Dados.Repositorios;
using Wevo.Dados.Transacoes;
using Wevo.Dominio.Contratos.Repositorios;
using Wevo.Dominio.Contratos.Servicos;
using Wevo.Dominio.Contratos.Transacoes;
using Wevo.Dominio.Servicos;

namespace Wevo.IoC
{
    public sealed class IoCConfig
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<EfContext>();
        }
    }
}
