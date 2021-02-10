using System.Threading.Tasks;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.UseCases.Interfaces
{
    public interface IAtualizarEditoraUseCase
    {
        Task<EditoraViewModel> Executar(int id, AtualizarEditoraCommand command);
    }
}