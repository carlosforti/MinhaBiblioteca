using System.Threading.Tasks;

namespace MinhaBiblioteca.Application.Interfaces.Data.Editora
{
    public interface IEditoraCommand
    {
        Task<Domain.Entities.Editora> AdicionarEditora(Domain.Entities.Editora editora);
        Task<Domain.Entities.Editora> AtualizarEditora(Domain.Entities.Editora editora);
        Task ExcluirEditora(int id);
    }
}