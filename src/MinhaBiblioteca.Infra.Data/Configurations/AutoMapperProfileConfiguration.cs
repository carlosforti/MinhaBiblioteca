using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MinhaBiblioteca.Infra.Data.Mappings;

namespace MinhaBiblioteca.Infra.Data.Configurations
{
    public static class AutoMapperProfileConfiguration
    {
        public static IServiceCollection ConfigurarAutoMapperData(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntidadeParaViewsProfile));
            return services;
        }
    }
}
