using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MinhaBiblioteca.Infra.Data.Repositories
{
    public class EditoraRepository : IEditoraCommand, IEditoraQuery
    {
        private const string NomeEntidade = "Editora";
        private const string EditoraNaoEncontrada = "Editora não encontrada";
        
        private readonly BibliotecaContext _context;
        private readonly INotificador _notifier;

        public EditoraRepository(BibliotecaContext context, INotificador notifier)
        {
            _context = context;
            _notifier = notifier;
        }

        public async Task<Editora> AdicionarEditora(Editora editora)
        {
            try
            {
                var resultado = await _context.Editoras.AddAsync(editora);
                await _context.SaveChangesAsync();
                return resultado.Entity;
            }
            catch (Exception e)
            {
                _notifier.AdicionarErro(NomeEntidade, e.Message, HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task<Editora> AtualizarEditora(Editora editora)
        {
            try
            {
                _context.Entry(editora).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return editora;
            }
            catch (Exception e)
            {
                _notifier.AdicionarErro(NomeEntidade, e.Message, HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task ExcluirEditora(int id)
        {
            var editora = await BuscarEditora(id);
            if (editora == null)
            {
                _notifier.AdicionarErro(NomeEntidade, EditoraNaoEncontrada, HttpStatusCode.NotFound);
                return;
            }

            _context.Remove(editora);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Editora>> ListarEditoras()
        {
            return await Task.FromResult(_context.Editoras.AsNoTracking());
        }

        public async Task<Editora> BuscarEditora(int id)
        {
            try
            {
                var editora = await _context.Editoras.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (editora == null)
                    _notifier.AdicionarErro(NomeEntidade, EditoraNaoEncontrada, HttpStatusCode.NoContent);
            
                return editora;
            }
            catch (Exception e)
            {
                _notifier.AdicionarErro("editora", e.Message, HttpStatusCode.InternalServerError);
                return null;
            }
        }
    }
}