using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.Interfaces.Data.Editora
{
    public interface IEditoraQuery
    {
        Task<IEnumerable<Domain.Entities.Editora>> ListarEditoras();
        Task<Domain.Entities.Editora> BuscarEditora(int id);
    }
}