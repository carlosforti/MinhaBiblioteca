using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Editoras;

namespace MinhaBiblioteca.Application.UseCases.Editoras
{
    public class ListarEditorasUseCase: IListarEditorasUseCase
    {
        private readonly IMapper _mapper;
        private readonly IEditoraRepository _editoraRepository;

        public ListarEditorasUseCase(IMapper mapper, IEditoraRepository editoraRepository)
        {
            _mapper = mapper;
            _editoraRepository = editoraRepository;
        }

        public async Task<IEnumerable<EditoraResumidaViewModel>> Executar()
        {
            var editoras = await _editoraRepository.ListarEditoras();
            return _mapper.Map<IEnumerable<EditoraResumidaViewModel>>(editoras);
        }
    }
}