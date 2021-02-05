using MinhaBiblioteca.Application.UseCases;
using MinhaBiblioteca.Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MinhaBiblioteca.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurarUseCases(this IServiceCollection services)
        {
            services.AddScoped<IListarEditorasUseCase, ListarEditorasUseCase>();
            services.AddScoped<IInserirEditoraUseCase, InserirEditoraUseCase>();
            services.AddScoped<IBuscarEditoraPorIdUseCase, BuscarEditoraPorIdUseCase>();

            return services;
        }
    }
}