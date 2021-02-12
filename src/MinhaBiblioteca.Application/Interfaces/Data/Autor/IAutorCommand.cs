using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.Interfaces.Data.Autor
{
    public interface IAutorCommand
    {
        Task<Domain.Entities.Autor> InserirAutor(Domain.Entities.Autor autor);
        Task<Domain.Entities.Autor> AtualizarAutor(Domain.Entities.Autor autor);
        Task ExcluirAutor(int id);
    }
}