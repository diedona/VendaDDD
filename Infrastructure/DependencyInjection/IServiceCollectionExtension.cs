using Infrastructure.Repositories;
using Infrastructure.Repositories.UoW;
using Infrastructure.Seguranca;
using Microsoft.Extensions.DependencyInjection;
using SegurancaBC.Domain.InfrastructureServices;
using SegurancaBC.Domain.Repositories;
using SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IHashService, GerenciadorDeHash>();
            services.AddScoped<ITokenService, GerenciadorDeToken>();
            return services;
        }
    }
}
