using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Interfaces;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.UseCases
{
    public class InserirEditoraUseCase: IInserirEditoraUseCase
    {
        private readonly IMapper _mapper;
        private readonly IEditoraCommand _editoraCommand;

        public InserirEditoraUseCase(IMapper mapper, IEditoraCommand editoraCommand)
        {
            _mapper = mapper;
            _editoraCommand = editoraCommand;
        }

        public async Task<EditoraViewModel> Executar(InserirEditoraCommand command)
        {
            var editora = _mapper.Map<Editora>(command);
            editora = await _editoraCommand.AdicionarEditora(editora);
            return _mapper.Map<EditoraViewModel>(editora);
        }
    }
}