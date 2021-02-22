using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Editoras;

namespace MinhaBiblioteca.Application.UseCases.Editoras.Interfaces
{
    public interface IAtualizarEditoraUseCase
    {
        Task<EditoraViewModel> Executar(int id, AtualizarEditoraViewModel viewModel);
    }
}