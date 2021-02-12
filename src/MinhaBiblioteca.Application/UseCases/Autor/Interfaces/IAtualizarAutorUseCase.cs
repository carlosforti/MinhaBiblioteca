using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Autor;

namespace MinhaBiblioteca.Application.UseCases.Autor.Interfaces
{
    public interface IAtualizarAutorUseCase
    {
        Task<AutorViewModel> Executar(int id, AtualizarAutorViewModel autorViewModel);
    }
}