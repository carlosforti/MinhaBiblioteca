using System;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Editoras;

namespace MinhaBiblioteca.Application.UseCases.Editoras.Interfaces
{
    public interface IAtualizarEditoraUseCase
    {
        Task<EditoraViewModel> Executar(Guid id, AtualizarEditoraViewModel viewModel);
    }
}