using Microsoft.Extensions.DependencyInjection;
using SegurancaBC.Application.UsuarioCases.FazerLogin;
using SegurancaBC.Domain.DomainServices;
using SegurancaBC.Domain.InfrastructureServices;
using SegurancaBC.Domain.Repositories;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Application.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSegurancaDependencies(this IServiceCollection services)
        {
            services.AddScoped<UsuarioDomainService>();
            services.AddScoped<FazerLoginUseCase>();
            return services;
        }
    }
}
