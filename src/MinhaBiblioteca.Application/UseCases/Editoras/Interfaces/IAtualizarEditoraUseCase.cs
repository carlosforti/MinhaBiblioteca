using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Editora;

namespace MinhaBiblioteca.Application.UseCases.Editoras.Interfaces
{
    public interface IAtualizarEditoraUseCase
    {
        Task<EditoraViewModel> Executar(int id, AtualizarEditoraViewModel viewModel);
    }
}