using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Autor;

namespace MinhaBiblioteca.Application.UseCases.Autor.Interfaces
{
    public interface IInserirAutorUseCase
    {
        Task<AutorViewModel> Executar(InserirAutorViewModel autorViewModel);
    }
}