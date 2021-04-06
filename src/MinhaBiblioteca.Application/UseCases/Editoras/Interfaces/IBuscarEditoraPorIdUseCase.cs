using System;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Editoras;

namespace MinhaBiblioteca.Application.UseCases.Editoras.Interfaces
{
    public interface IBuscarEditoraPorIdUseCase
    {
        Task<EditoraViewModel> Executar(Guid id);
    }
}