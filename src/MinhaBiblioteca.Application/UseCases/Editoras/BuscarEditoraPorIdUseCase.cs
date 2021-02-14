using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Editoras
{
    public class BuscarEditoraPorIdUseCase: IBuscarEditoraPorIdUseCase
    {
        private readonly IEditoraRepository _editoraRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public BuscarEditoraPorIdUseCase(IEditoraRepository editoraRepository, INotificador notificador, IMapper mapper)
        {
            _editoraRepository = editoraRepository;
            _notificador = notificador;
            _mapper = mapper;
        }

        public async Task<EditoraViewModel> Executar(int id)
        {
            var editora = await _editoraRepository.BuscarEditora(id);
            return _notificador.TemErros ? null : _mapper.Map<EditoraViewModel>(editora);
        }
    }
}