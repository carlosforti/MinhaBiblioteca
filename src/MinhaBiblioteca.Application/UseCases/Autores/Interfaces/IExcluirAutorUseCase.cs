using System;
using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.UseCases.Autores.Interfaces
{
    public interface IExcluirAutorUseCase
    {
        Task Executar(Guid id);
    }
}