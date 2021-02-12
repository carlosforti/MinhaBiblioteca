using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editora.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Editora;

namespace MinhaBiblioteca.Application.UseCases.Editora
{
    public class InserirEditoraUseCase: IInserirEditoraUseCase
    {
        private readonly IMapper _mapper;
        private readonly IEditoraRepository _editoraRepository;

        public InserirEditoraUseCase(IMapper mapper, IEditoraRepository editoraRepository)
        {
            _mapper = mapper;
            _editoraRepository = editoraRepository;
        }

        public async Task<EditoraViewModel> Executar(InserirEditoraViewModel viewModel)
        {
            var editora = _mapper.Map<Domain.Entities.Editora>(viewModel);
            editora = await _editoraRepository.AdicionarEditora(editora);
            return _mapper.Map<EditoraViewModel>(editora);
        }
    }
}