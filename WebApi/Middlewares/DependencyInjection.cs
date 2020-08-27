using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Configurations;
using WebApi.Configurations;
using Infrastructure.Repositories.UoW;
using SharedKernel.Repositories;
using SegurancaBC.Domain.Repositories;
using Infrastructure.Repositories;
using SegurancaBC.Domain.InfrastructureServices;
using Infrastructure.Seguranca;
using SegurancaBC.Domain.DomainServices;
using Infrastructure.DependencyInjection;
using SegurancaBC.Application.DependencyInjection;

namespace WebApi.Middlewares
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionData, ConnectionData>();
            services.AddSingleton<ITokenData, TokenData>();
            services.AddInfrastructureDependencies();
            services.AddSegurancaDependencies();
        }
    }
}
