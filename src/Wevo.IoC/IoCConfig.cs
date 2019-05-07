using Microsoft.Extensions.DependencyInjection;
using Wevo.Dados.Contextos;
using Wevo.Dados.Repositorios;
using Wevo.Dados.Transacoes;
using Wevo.Dominio.Contratos.Repositorios;
using Wevo.Dominio.Contratos.Servicos;
using Wevo.Dominio.Contratos.Transacoes;
using Wevo.Dominio.Servicos;
using Wevo.NucleoCompartilhado.DomainEvents.Core;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.IoC
{
    public sealed class IoCConfig
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddDbContext<EfContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            DomainEvent.ServiceProvider = services.BuildServiceProvider();
        }
    }
}
