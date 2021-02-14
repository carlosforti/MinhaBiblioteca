using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.UseCases.Editoras
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
            var editora = _mapper.Map<Editora>(viewModel);
            editora = await _editoraRepository.AdicionarEditora(editora);
            return _mapper.Map<EditoraViewModel>(editora);
        }
    }
}