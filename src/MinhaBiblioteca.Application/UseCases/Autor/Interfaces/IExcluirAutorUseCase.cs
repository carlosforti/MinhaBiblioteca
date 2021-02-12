using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.UseCases.Autor.Interfaces
{
    public interface IExcluirAutorUseCase
    {
        Task Executar(int id);
    }
}