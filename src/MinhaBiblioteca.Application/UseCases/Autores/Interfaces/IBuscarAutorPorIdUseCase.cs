using System;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Autores;

namespace MinhaBiblioteca.Application.UseCases.Autores.Interfaces
{
    public interface IBuscarAutorPorIdUseCase
    {
        Task<AutorViewModel> Executar(Guid id);
    }
}