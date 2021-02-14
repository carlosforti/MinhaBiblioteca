using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Livros;

namespace MinhaBiblioteca.Application.UseCases.Livros.Interfaces
{
    public interface IAtualizarLivoUseCase
    {
        Task<LivroViewModel> Executar(int id, AtualizarLivroViewModel atualizarLivroViewModel);
    }

    public interface IInserirLivroUseCase
    {
        Task<LivroViewModel> Executar(InserirLivroViewModel inserirLivroViewModel);
    }
}