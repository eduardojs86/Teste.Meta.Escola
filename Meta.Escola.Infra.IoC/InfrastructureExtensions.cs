using Meta.Escola.ApplicationCore.Domain._Ports.Repositories;
using Meta.Escola.ApplicationCore.Domain.Model;
using Meta.Escola.Infra.PersistenceAdapter.ADOSqlCommand;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meta.Escola.Infra.IoC
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddPersistenceAdapters(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Infra.PersistenceAdapter.ADOSqlCommand.EscolaDBContext>();
            services.AddScoped<IEscolaRetository<object>, EscolaRepository>();
            return services;
        }
    }
}
