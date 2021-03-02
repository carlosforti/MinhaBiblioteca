using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Microsoft.Extensions.DependencyInjection;

namespace MinhaBiblioteca.Infra.Shared.Configurations
{
    public static class DependencynjectionConfiguration
    {
        public static IServiceCollection ConfigureShared(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}