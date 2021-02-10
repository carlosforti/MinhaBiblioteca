using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.UseCases.Interfaces
{
    public interface IExcluirEditoraUseCase
    {
        Task Executar(int id);
    }
}