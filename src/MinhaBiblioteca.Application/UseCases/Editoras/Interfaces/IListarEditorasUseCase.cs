using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Editora;

namespace MinhaBiblioteca.Application.UseCases.Editoras.Interfaces
{
    public interface IListarEditorasUseCase
    {
        Task<IEnumerable<EditoraResumidaViewModel>> Executar();
    }
}