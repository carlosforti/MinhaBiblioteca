using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Interfaces.Data.Autores
{
    public interface IAutorQuery
    {
        Task<IEnumerable<Autor>> ListarAutores();
        Task<Autor> BuscarAutorPorId(int id);
    }
}