using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaBiblioteca.Application.UseCases.Autores;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.UseCases.Editoras;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.UseCases.Livros;
using MinhaBiblioteca.Application.UseCases.Livros.Interfaces;

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
            services.AddScoped<IAtualizarEditoraUseCase, AtualizarEditoraUseCase>();
            services.AddScoped<IExcluirEditoraUseCase, ExcluirEditoraUseCase>();

            services.AddScoped<IListarAutoresUseCase, ListarAutoresUseCase>();
            services.AddScoped<IBuscarAutorPorIdUseCase, BuscarAutorPorIdUseCase>();
            services.AddScoped<IInserirAutorUseCase, InserirAutorUseCase>();
            services.AddScoped<IAtualizarAutorUseCase, AtualizarAutorUseCase>();
            services.AddScoped<IExcluirAutorUseCase, ExcluirAutorUseCase>();

            services.AddScoped<IListarLivrosUseCase, ListarLivrosUseCase>();
            services.AddScoped<IBuscarLivroPorIdUseCase, BuscarLivroPorIdUseCase>();
            services.AddScoped<IInserirLivroUseCase, InserirLivroUseCase>();
            services.AddScoped<IAtualizarLivroUseCase, AtualizarLivroUseCase>();
            services.AddScoped<IExcluirLivroUseCase, ExcluirLivroUseCase>();

            return services;
        }
    }
}