using MinhaBiblioteca.Application.UseCases;
using MinhaBiblioteca.Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MinhaBiblioteca.Application.Cqrs.Commands;

namespace MinhaBiblioteca.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurarUseCases(this IServiceCollection services)
        {
            services.AddScoped<IListarEditorasUseCase, ListarEditorasUseCase>();
            services.AddScoped<IBuscarEditoraPorIdUseCase, BuscarEditoraPorIdUseCase>();
            services.AddScoped<IInserirEditoraUseCase, InserirEditoraUseCase>();
            services.AddScoped<IAtualizarEditoraUseCase, AtualizarEdiitoraUseCase>();
            services.AddScoped<IExcluirEditoraUseCase, ExcluirEditoraUseCase>();

            return services;
        }
    }
}