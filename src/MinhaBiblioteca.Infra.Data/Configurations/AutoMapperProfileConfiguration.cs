using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MinhaBiblioteca.Infra.Data.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaBiblioteca.Infra.Data.Configurations
{
    public static class AutoMapperProfileConfiguration
    {
        public static IServiceCollection ConfigurarAutoMapperData(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(LivroView));
            return services;
        }
    }
}
