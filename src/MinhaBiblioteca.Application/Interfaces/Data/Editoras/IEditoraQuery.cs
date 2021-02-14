using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Interfaces.Data.Editoras
{
    public interface IEditoraQuery
    {
        Task<IEnumerable<Editora>> ListarEditoras();
        Task<Editora> BuscarEditora(int id);
    }
}