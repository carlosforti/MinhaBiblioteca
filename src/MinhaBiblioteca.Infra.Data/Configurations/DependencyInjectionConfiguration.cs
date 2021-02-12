using Microsoft.EntityFrameworkCore;
using MinhaBiblioteca.Infra.Data.Context;
using MinhaBiblioteca.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.Interfaces.Data.Editora;

namespace MinhaBiblioteca.Infra.Data.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigurarInfraData(this IServiceCollection services,
            IConfiguration configuration)
        {
            // services.AddScoped<IEditoraCommand, EditoraRepository>();
            // services.AddScoped<IEditoraQuery, EditoraRepository>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
#if DEBUG
            services.AddDbContext<BibliotecaContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "BibliotecaContext");
            });
#else
             var connectionString = configuration.GetConnectionString("BibliotecaContext");
             services.AddDbContext<BibliotecaContext>(options =>
             {
                 options.UseSqlServer(connectionString);
             });
#endif

            return services;
        }
    }
}