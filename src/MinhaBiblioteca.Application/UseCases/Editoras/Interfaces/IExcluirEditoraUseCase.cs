using System;
using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.UseCases.Editoras.Interfaces
{
    public interface IExcluirEditoraUseCase
    {
        Task Executar(Guid id);
    }
}