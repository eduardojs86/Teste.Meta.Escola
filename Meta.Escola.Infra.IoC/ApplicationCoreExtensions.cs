using Meta.Escola.ApplicationCore.Application._Ports.Services;
using Meta.Escola.ApplicationCore.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Escola.Infra.IoC
{
    public static class ApplicationCoreExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEscolaApplicationService, EscolaApplicationServices>();
            return services;
        }
    }
}
