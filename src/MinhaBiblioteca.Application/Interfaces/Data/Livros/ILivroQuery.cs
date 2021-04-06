using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Interfaces.Data.Livros
{
    public interface ILivroQuery
    {
        Task<IEnumerable<Livro>> ListarLivros();
        Task<Livro> BuscarLivroPorId(Guid id);
    }
}