using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Interfaces;
using MinhaBiblioteca.Application.ViewModels;

namespace MinhaBiblioteca.Application.UseCases
{
    public class ListarEditorasUseCase: IListarEditorasUseCase
    {
        private readonly IMapper _mapper;
        private readonly IEditoraQuery _editoraQuery;

        public ListarEditorasUseCase(IMapper mapper, IEditoraQuery editoraQuery)
        {
            _mapper = mapper;
            _editoraQuery = editoraQuery;
        }

        public async Task<IEnumerable<EditoraResumidaViewModel>> Executar()
        {
            var editoras = await _editoraQuery.ListarEditoras();
            return _mapper.Map<IEnumerable<EditoraResumidaViewModel>>(editoras);
        }
    }
}