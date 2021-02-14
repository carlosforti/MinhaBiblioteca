using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.UseCases.Interfaces
{
    public interface IBuscarEditoraPorIdUseCase
    {
        Task<Editora> Executar(int id);
    }
}