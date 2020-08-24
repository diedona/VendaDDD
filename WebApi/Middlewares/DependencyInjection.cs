using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Connection;
using WebApi.Connection;
using Infrastructure.Repositories.UoW;
using SharedKernel.Repositories;
using SegurancaBC.Domain.Repositories;
using Infrastructure.Repositories;
using SegurancaBC.Domain.InfrastructureServices;
using Infrastructure.Seguranca;
using SegurancaBC.Domain.DomainServices;
using SegurancaBC.Domain.ApplicationServices;

namespace WebApi.Middlewares
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionData, ConnectionData>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IHashService, GerenciadorDeHash>();
            services.AddScoped<UsuarioDomainService>();
            services.AddScoped<UsuarioApplicationService>();
        }
    }
}
