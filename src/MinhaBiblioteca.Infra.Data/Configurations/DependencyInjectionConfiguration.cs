using Microsoft.EntityFrameworkCore;
using MinhaBiblioteca.Infra.Data.Context;
using MinhaBiblioteca.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaBiblioteca.Application.Interfaces.Data;

namespace MinhaBiblioteca.Infra.Data.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigurarInfraData(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.ConfigurarDbContext(configuration);

            return services;
        }

        private static IServiceCollection ConfigurarDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            if (configuration == null)
                return services.AddDbContext<BibliotecaContext>(options =>
                    options.UseInMemoryDatabase("BibliotecaContext"));

            var connectionString = configuration.GetConnectionString("BibliotecaContext");
            var ambienteProducao = configuration?["Environment"] == "Production";

            if (ambienteProducao || configuration["ForceProduction"] == "true")
                return services.AddDbContext<BibliotecaContext>(options =>
                    options.UseSqlServer(connectionString));

            return services.AddDbContext<BibliotecaContext>(options =>
                    options.UseInMemoryDatabase("BibliotecaContext"));
        }
    }
}