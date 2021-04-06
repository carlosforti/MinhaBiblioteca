using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.Infra.Data.Context;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Repositories
{
    public class RepositoryBase
    {
        protected BibliotecaContext Context;
        protected INotificador Notifier;
        protected IMapper Mapper;
    }

    public class EditoraRepository : RepositoryBase, IEditoraRepository
    {
        private const string NomeEntidade = "Editora";
        private const string EditoraNaoEncontrada = "Editora não encontrada";

        public EditoraRepository(BibliotecaContext context, INotificador notifier, IMapper mapper)
        {
            Context = context;
            Notifier = notifier;
            Mapper = mapper;
        }

        public async Task<Editora> AdicionarEditora(Editora editora)
        {
            try
            {
                var view = Mapper.Map<EditoraView>(editora);
                view.Id = Guid.NewGuid();
                var resultado = await Context.Editoras.AddAsync(view);
                await Context.SaveChangesAsync();
                return Mapper.Map<Editora>(resultado.Entity);
            }
            catch (Exception e)
            {
                Notifier.AdicionarErro(NomeEntidade, e.Message, HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task<Editora> AtualizarEditora(Editora editora)
        {
            try
            {
                // _context.Entry(editora).State = EntityState.Modified;
                Context.Update(editora);
                await Context.SaveChangesAsync();
                return editora;
            }
            catch (Exception e)
            {
                Notifier.AdicionarErro(NomeEntidade, e.Message, HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task ExcluirEditora(Guid id)
        {
            var editora = await BuscarEditoraPorId(id);
            if (editora == null)
            {
                Notifier.AdicionarErro(NomeEntidade, EditoraNaoEncontrada, HttpStatusCode.NotFound);
                return;
            }

            Context.Remove(editora);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Editora>> ListarEditoras()
        {
            var editoras = Context.Editoras.AsNoTracking();
            return await Task.FromResult(Mapper.Map<IEnumerable<Editora>>(editoras));
        }

        public async Task<Editora> BuscarEditoraPorId(Guid id)
        {
            try
            {
                var editora = await Context.Editoras.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (editora == null)
                    Notifier.AdicionarErro(NomeEntidade, EditoraNaoEncontrada, HttpStatusCode.NoContent);
            
                return Mapper.Map<Editora>(editora);
            }
            catch (Exception e)
            {
                Notifier.AdicionarErro("editora", e.Message, HttpStatusCode.InternalServerError);
                return null;
            }
        }
    }
}