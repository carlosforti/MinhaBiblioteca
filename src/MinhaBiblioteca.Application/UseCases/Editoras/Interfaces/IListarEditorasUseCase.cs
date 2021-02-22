using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Editoras;

namespace MinhaBiblioteca.Application.UseCases.Editoras.Interfaces
{
    public interface IListarEditorasUseCase
    {
        Task<IEnumerable<EditoraResumidaViewModel>> Executar();
    }
}