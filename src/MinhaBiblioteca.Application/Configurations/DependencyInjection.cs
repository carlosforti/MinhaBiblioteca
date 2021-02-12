using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaBiblioteca.Application.UseCases.Editora;
using MinhaBiblioteca.Application.UseCases.Editora.Interfaces;

namespace MinhaBiblioteca.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurarUseCases(this IServiceCollection services,
                                                            IConfiguration configuration)
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