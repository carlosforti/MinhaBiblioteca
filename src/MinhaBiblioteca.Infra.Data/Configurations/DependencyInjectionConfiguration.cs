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
            services.ConfigurarDbContext(configuration);

            return services;
        }

        private static IServiceCollection ConfigurarDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = new DbContextOptionsBuilder();

            if (configuration == null)
                builder.UseInMemoryDatabase(databaseName: "BibliotecaContext");

            var connectionString = configuration.GetConnectionString("BibliotecaContext");
            var ambienteProducao = configuration?["Environment"] == "Production";

            if (ambienteProducao)
                services.AddDbContext<BibliotecaContext>(options =>
                    builder.UseSqlServer(connectionString));
            else
                services.AddDbContext<BibliotecaContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "BibliotecaContext"));

            return services;
        }
    }
}