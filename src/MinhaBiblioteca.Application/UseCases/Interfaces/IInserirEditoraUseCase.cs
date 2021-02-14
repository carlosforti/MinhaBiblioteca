using System.Threading.Tasks;
using MinhaBiblioteca.Application.Cqrs.Commands;

namespace MinhaBiblioteca.Application.UseCases.Interfaces
{
    public interface IInserirEditoraUseCase
    {
        Task<AtualizarEditoraCommand> Executar(InserirEditoraCommand command);
    }
}