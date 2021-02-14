using MinhaBiblioteca.Application.Interfaces.Data.Livros;

namespace MinhaBiblioteca.Application.Interfaces.Data
{
    public interface ILivroRepository: ILivroQuery, ILivroCommand
    {
    }
}