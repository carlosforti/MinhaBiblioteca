using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Interfaces;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases
{
    public class BuscarEditoraPorIdUseCase: IBuscarEditoraPorIdUseCase
    {
        private readonly IEditoraQuery _editoraQuery;
        private readonly INotificador _notificador;

        public BuscarEditoraPorIdUseCase(IEditoraQuery editoraQuery, INotificador notificador)
        {
            _editoraQuery = editoraQuery;
            _notificador = notificador;
        }

        public async Task<Editora> Executar(int id)
        {
            var editora = await _editoraQuery.BuscarEditora(id);
            return _notificador.TemErros ? null : editora;
        }
    }
}