using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.UseCases.Editora.Interfaces
{
    public interface IExcluirEditoraUseCase
    {
        Task Executar(int id);
    }
}