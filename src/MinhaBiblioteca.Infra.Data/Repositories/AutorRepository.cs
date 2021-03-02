using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Data.Context;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Infra.Data.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private const string NomeEntidade = "Autor";
        private const string AutorNaoEncontrado = "Autor Não Encontrado";

        private readonly BibliotecaContext _context;
        private readonly INotificador _notificador;

        public AutorRepository(BibliotecaContext context, INotificador notificador)
        {
            _context = context;
            _notificador = notificador;
        }

        public async Task<IEnumerable<Autor>> ListarAutores()
        {
            return await Task.FromResult(_context.Autores.AsNoTracking());
        }

        public async Task<Autor> BuscarAutorPorId(int id)
        {
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);
                if (autor == null)
                    _notificador.AdicionarErro(NomeEntidade,
                                               AutorNaoEncontrado,
                                               System.Net.HttpStatusCode.NoContent);

                return autor;
            }
            catch (System.Exception ex)
            {
                _notificador.AdicionarErro(NomeEntidade, ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task<Autor> InserirAutor(Autor autor)
        {
            try
            {
                var resultado = await _context.Autores.AddAsync(autor);
                await _context.SaveChangesAsync();

                return resultado.Entity;
            }
            catch (System.Exception ex)
            {
                _notificador.AdicionarErro(NomeEntidade, ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task<Autor> AtualizarAutor(Autor autor)
        {
            try
            {
                _context.Update(autor);
                await _context.SaveChangesAsync();
                return autor;
            }
            catch (System.Exception ex)
            {
                _notificador.AdicionarErro(NomeEntidade, ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task ExcluirAutor(int id)
        {
            var autor = await BuscarAutorPorId(id);
            if (_notificador.ExistemErros) return;

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
        }
    }
}