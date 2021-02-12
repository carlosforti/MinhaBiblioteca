using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Editora;

namespace MinhaBiblioteca.Application.UseCases.Editora.Interfaces
{
    public interface IBuscarEditoraPorIdUseCase
    {
        Task<EditoraViewModel> Executar(int id);
    }
}