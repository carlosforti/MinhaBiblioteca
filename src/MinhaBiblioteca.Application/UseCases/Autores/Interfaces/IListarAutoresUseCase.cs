using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Autores;

namespace MinhaBiblioteca.Application.UseCases.Autores.Interfaces
{
    public interface IListarAutoresUseCase
    {
        Task<IEnumerable<AutorResumidoViewModel>> Executar();
    }
}