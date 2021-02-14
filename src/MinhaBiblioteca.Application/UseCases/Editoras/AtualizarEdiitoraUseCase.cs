using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Editoras
{
    public class AtualizarEdiitoraUseCase: IAtualizarEditoraUseCase
    {
        private readonly IMapper _mapper;
        private readonly IEditoraRepository _editoraRepository;
        private readonly INotificador _notificador;
        
        public AtualizarEdiitoraUseCase(IMapper mapper, IEditoraRepository editoraRepository, INotificador notificador)
        {
            _mapper = mapper;
            _editoraRepository = editoraRepository;
            _notificador = notificador;
        }

        public async Task<EditoraViewModel> Executar(int id, AtualizarEditoraViewModel viewModel)
        {
            if (viewModel.Id != id)
            {
                _notificador.AdicionarErro("id", "Id informado não corresponde ao da rota");
                return null;
            }
            var editora = _mapper.Map<Editora>(viewModel);
            await _editoraRepository.AtualizarEditora(editora);
            return _notificador.TemErros ? null : _mapper.Map<EditoraViewModel>(editora);
        }
    }
}