using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels;

namespace MinhaBiblioteca.Application.UseCases.Interfaces
{
    public interface IListarEditorasUseCase
    {
        Task<IEnumerable<EditoraResumidaViewModel>> Executar();
    }
}