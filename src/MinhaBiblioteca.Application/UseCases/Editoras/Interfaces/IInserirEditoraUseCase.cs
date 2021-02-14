using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Editora;

namespace MinhaBiblioteca.Application.UseCases.Editoras.Interfaces
{
    public interface IInserirEditoraUseCase
    {
        Task<EditoraViewModel> Executar(InserirEditoraViewModel viewModel);
    }
}