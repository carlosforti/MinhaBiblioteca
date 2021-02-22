using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.ViewModels.Livros;

namespace MinhaBiblioteca.Application.UseCases.Livros.Interfaces
{
    public interface IListarLivrosUseCase
    {
        Task<IEnumerable<LivroResumidoViewModel>> Executar();
    }
}