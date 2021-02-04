using System.Linq;
using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Interfaces.Data
{
    public interface IEditoraQuery
    {
        Task<IQueryable<Editora>> ListarEditoras();
        Task<Editora> BuscarEditora(int id);
    }
}