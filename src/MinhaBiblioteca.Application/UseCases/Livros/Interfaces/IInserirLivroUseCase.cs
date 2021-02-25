using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Livros;

namespace MinhaBiblioteca.Application.UseCases.Livros.Interfaces
{
    public interface IInserirLivroUseCase
    {
        Task<LivroViewModel> Executar(InserirLivroViewModel livroViewModel);
    }
}