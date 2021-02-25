using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Livros;

namespace MinhaBiblioteca.Application.UseCases.Livros.Interfaces
{
    public interface IAtualizarLivroUseCase
    {
        Task<LivroViewModel> Executar(int id, AtualizarLivroViewModel atualizarLivroViewModel);
    }
}