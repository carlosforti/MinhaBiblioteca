using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Livros;

namespace MinhaBiblioteca.Application.UseCases.Livros.Interfaces
{
    public interface IBuscarLivroPorIdUseCase
    {
        Task<LivroViewModel> Executar(int id);
    }
}