using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Data.Context;
using MinhaBiblioteca.Infra.Data.Views;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Infra.Data.Repositories
{
    public class AutorRepository : RepositoryBase, IAutorRepository
    {
        private const string NomeEntidade = "Autor";
        private const string AutorNaoEncontrado = "Autor Não Encontrado";

        public AutorRepository(BibliotecaContext context, INotificador notificador, IMapper mapper)
            : base(context, notificador, mapper)
        {
        }

        public async Task<IEnumerable<Autor>> ListarAutores()
        {
            var autores = Context.Autores.AsNoTracking();
            return await Task.FromResult(Mapper.Map<IEnumerable<Autor>>(autores));
        }

        public async Task<Autor> BuscarAutorPorId(Guid id)
        {
            try
            {
                var autor = await Context.Autores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (autor == null)
                    Notifier.AdicionarErro(NomeEntidade,
                        AutorNaoEncontrado,
                        System.Net.HttpStatusCode.NotFound);

                return Mapper.Map<Autor>(autor);
            }
            catch (Exception ex)
            {
                Notifier.AdicionarErro(NomeEntidade, ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task<Autor> InserirAutor(Autor autor)
        {
            try
            {
                var view = Mapper.Map<AutorView>(autor);
                view.Id = Guid.NewGuid();
                var resultado = await Context.Autores.AddAsync(view);
                await Context.SaveChangesAsync();

                return Mapper.Map<Autor>(resultado.Entity);
            }
            catch (Exception ex)
            {
                Notifier.AdicionarErro(NomeEntidade, ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task<Autor> AtualizarAutor(Autor autor)
        {
            try
            {
                var atual = await BuscarAutorPorId(autor.Id);
                if(atual == null)
                    return null;

                var view = Mapper.Map<AutorView>(autor);
                Context.Entry(view).State = EntityState.Modified;

                await Context.SaveChangesAsync();
                return autor;
            }
            catch (Exception ex)
            {
                Notifier.AdicionarErro(NomeEntidade, ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task ExcluirAutor(Guid id)
        {
            var autor = await BuscarAutorPorId(id);
            if (Notifier.ExistemErros) return;

            var view = Mapper.Map<AutorView>(autor);
            Context.Autores.Remove(view);
            await Context.SaveChangesAsync();
        }
    }
}