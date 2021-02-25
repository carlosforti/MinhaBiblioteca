using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Interfaces.Data.Editoras
{
    public interface IEditoraCommand
    {
        Task<Editora> AdicionarEditora(Editora editora);
        Task<Editora> AtualizarEditora(Editora editora);
        Task ExcluirEditora(int id);
    }
}