using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Interfaces;

namespace MinhaBiblioteca.Application.UseCases
{
    public class ExcluirEditoraUseCase: IExcluirEditoraUseCase
    {
        private readonly IEditoraCommand _editoraCommand;

        public ExcluirEditoraUseCase(IEditoraCommand editoraCommand)
        {
            _editoraCommand = editoraCommand;
        }

        public async Task Executar(int id)
        {
            await _editoraCommand.ExcluirEditora(id);
        }
    }
}