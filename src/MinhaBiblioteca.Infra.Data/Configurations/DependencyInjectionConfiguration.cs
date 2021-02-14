using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Infra.Data.Context;
using MinhaBiblioteca.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MinhaBiblioteca.Infra.Data.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AdicionarCommandsQueries(this IServiceCollection services)
        {
            services.AddScoped<IEditoraCommand, EditoraRepository>();
            services.AddScoped<IEditoraQuery, EditoraRepository>();

            return services;
        }

        public static IServiceCollection AdicionarBibliotecaContext(this IServiceCollection services, IConfiguration configuration)
        {
            // var connectionString =  configuration.GetConnectionString("BibliotecaContext");
            // services.AddDbContext<BibliotecaContext>(options =>
            // {
            //     options.UseSqlServer(connectionString);
            // });

            services.AddDbContext<BibliotecaContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "BibliotecaContext");
            });
            
            return services;
        }
    }
}