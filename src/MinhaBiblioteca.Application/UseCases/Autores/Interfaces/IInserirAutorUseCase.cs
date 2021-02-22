using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Autores;

namespace MinhaBiblioteca.Application.UseCases.Autores.Interfaces
{
    public interface IInserirAutorUseCase
    {
        Task<AutorViewModel> Executar(InserirAutorViewModel autorViewModel);
    }
}