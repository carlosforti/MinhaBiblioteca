using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Autores;

namespace MinhaBiblioteca.Application.UseCases.Autores.Interfaces
{
    public interface IAtualizarAutorUseCase
    {
        Task<AutorViewModel> Executar(int id, AtualizarAutorViewModel autorViewModel);
    }
}