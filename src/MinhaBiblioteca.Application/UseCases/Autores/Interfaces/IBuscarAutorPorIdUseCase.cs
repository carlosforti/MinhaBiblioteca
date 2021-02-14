using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Autor;

namespace MinhaBiblioteca.Application.UseCases.Autores.Interfaces
{
    public interface IBuscarAutorPorIdUseCase
    {
        Task<AutorViewModel> Executar(int id);
    }
}