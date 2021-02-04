using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Interfaces.Data
{
    public interface IEditoraCommand
    {
        Task<Editora> AdicionarEditora(Editora editora);
        Task<Editora> AtualizarEditora(Editora editora);
        Task ExcluirEditora(int Id);
    }
}