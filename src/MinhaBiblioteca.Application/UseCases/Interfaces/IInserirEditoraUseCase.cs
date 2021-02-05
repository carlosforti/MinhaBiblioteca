using System.Threading.Tasks;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Application.ViewModels;

namespace MinhaBiblioteca.Application.UseCases.Interfaces
{
    public interface IInserirEditoraUseCase
    {
        Task<EditoraViewModel> Executar(InserirEditoraCommand command);
    }
}