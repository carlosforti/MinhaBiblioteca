using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editora.Interfaces;

namespace MinhaBiblioteca.Application.UseCases.Editora
{
    public class ExcluirEditoraUseCase: IExcluirEditoraUseCase
    {
        private readonly IEditoraRepository _editoraRepository;

        public ExcluirEditoraUseCase(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public async Task Executar(int id)
        {
            await _editoraRepository.ExcluirEditora(id);
        }
    }
}