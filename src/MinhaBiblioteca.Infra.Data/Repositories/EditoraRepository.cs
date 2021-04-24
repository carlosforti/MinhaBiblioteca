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
    public class EditoraRepository : RepositoryBase, IEditoraRepository
    {
        private const string NomeEntidade = "Editora";
        private const string EditoraNaoEncontrada = "Editora não encontrada";

        public EditoraRepository(BibliotecaContext context, INotificador notifier, IMapper mapper)
            : base(context, notifier, mapper)
        {
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
                var atual = await BuscarEditoraPorId(editora.Id);
                if(atual == null)
                    return null;

                var view = Mapper.Map<EditoraView>(editora);
                Context.Update(view);
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
            if (Notifier.ExistemErros) return;

            var view = Mapper.Map<EditoraView>(editora);
            Context.Editoras.Remove(view);
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
                    Notifier.AdicionarErro(NomeEntidade, EditoraNaoEncontrada, HttpStatusCode.NotFound);

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