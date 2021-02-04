using AutoMapper;
using MinhaBiblioteca.Application.Mapeamentos;
using Microsoft.Extensions.DependencyInjection;

namespace MinhaBiblioteca.Application.Configurations
{
    public static class AutoMapperProfileConfiguration
    {
        public static IServiceCollection ConfigurarAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommandsParaEntidadesProfile));
            return services;
        }
    }
}