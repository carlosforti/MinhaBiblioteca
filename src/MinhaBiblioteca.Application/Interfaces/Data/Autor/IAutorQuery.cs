using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.Interfaces.Data.Autor
{
    public interface IAutorQuery
    {
        Task<IEnumerable<Domain.Entities.Autor>> ListarAutores();
        Task<Domain.Entities.Autor> BuscarAutorPorId(int id);
    }
}