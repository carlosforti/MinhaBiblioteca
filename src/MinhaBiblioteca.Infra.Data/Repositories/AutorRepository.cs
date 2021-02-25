using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Infra.Data.Repositories
{
    public class AutorRepository: IAutorRepository
    {
        public Task<IEnumerable<Autor>> ListarAutores()
        {
            throw new System.NotImplementedException();
        }

        public Task<Autor> BuscarAutorPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Autor> InserirAutor(Autor autor)
        {
            throw new System.NotImplementedException();
        }

        public Task<Autor> AtualizarAutor(Autor autor)
        {
            throw new System.NotImplementedException();
        }

        public Task ExcluirAutor(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}