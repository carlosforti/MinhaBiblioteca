using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Interfaces;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases
{
    public class AtualizarEdiitoraUseCase: IAtualizarEditoraUseCase
    {
        private readonly IMapper _mapper;
        private readonly IEditoraCommand _editoraCommand;
        private readonly INotificador _notificador;
        
        public AtualizarEdiitoraUseCase(IMapper mapper, IEditoraCommand editoraCommand, INotificador notificador)
        {
            _mapper = mapper;
            _editoraCommand = editoraCommand;
            _notificador = notificador;
        }

        public async Task<EditoraViewModel> Executar(int id, AtualizarEditoraCommand command)
        {
            if (command.Id != id)
            {
                _notificador.AdicionarErro("id", "Id informado não corresponde ao da rota");
                return null;
            }
            var editora = _mapper.Map<Editora>(command);
            await _editoraCommand.AtualizarEditora(editora);

            return _notificador.TemErros ? null : _mapper.Map<EditoraViewModel>(editora);
        }
    }
}