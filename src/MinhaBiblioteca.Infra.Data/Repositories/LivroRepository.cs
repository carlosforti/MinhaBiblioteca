using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Infra.Data.Repositories
{
    public class LivroRepository: ILivroRepository
    {
        public Task<IEnumerable<Livro>> ListarLivros()
        {
            throw new System.NotImplementedException();
        }

        public Task<Livro> BuscarLivroPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Livro> InserirLivro(Livro livro)
        {
            throw new System.NotImplementedException();
        }

        public Task<Livro> AtualizarLivro(Livro livro)
        {
            throw new System.NotImplementedException();
        }

        public Task ExcluirLivro(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}