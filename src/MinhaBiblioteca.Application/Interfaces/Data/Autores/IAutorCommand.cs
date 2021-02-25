using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Interfaces.Data.Autores
{
    public interface IAutorCommand
    {
        Task<Autor> InserirAutor(Autor autor);
        Task<Autor> AtualizarAutor(Autor autor);
        Task ExcluirAutor(int id);
    }
}