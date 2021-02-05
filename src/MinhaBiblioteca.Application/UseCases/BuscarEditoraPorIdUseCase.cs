using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Interfaces;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases
{
    public class BuscarEditoraPorIdUseCase: IBuscarEditoraPorIdUseCase
    {
        private readonly IEditoraQuery _editoraQuery;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public BuscarEditoraPorIdUseCase(IEditoraQuery editoraQuery, INotificador notificador, IMapper mapper)
        {
            _editoraQuery = editoraQuery;
            _notificador = notificador;
            _mapper = mapper;
        }

        public async Task<EditoraViewModel> Executar(int id)
        {
            var editora = await _editoraQuery.BuscarEditora(id);
            if (_notificador.TemErros)
                return null;
            
            return _mapper.Map<EditoraViewModel>(editora);
        }
    }
}