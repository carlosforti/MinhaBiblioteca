using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.UseCases.Livros.Interfaces
{
    public interface IExcluirLivroUseCase
    {
        Task Executar(int id);
    }
}