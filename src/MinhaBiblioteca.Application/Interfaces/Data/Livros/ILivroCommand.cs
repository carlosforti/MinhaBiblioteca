using System;
using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Interfaces.Data.Livros
{
    public interface ILivroCommand
    {
        Task<Livro> InserirLivro(Livro livro);
        Task<Livro> AtualizarLivro(Livro livro);
        Task ExcluirLivro(Guid id);
    }
}