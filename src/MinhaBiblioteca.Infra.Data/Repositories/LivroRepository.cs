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
    public class LivroRepository : RepositoryBase, ILivroRepository
    {
        private const string NomeEntidade = "Livro";
        private const string LivroNaoEncontrada = "Livro não encontrado";


        public LivroRepository(BibliotecaContext context, INotificador notifier, IMapper mapper)
            : base(context, notifier, mapper)
        {
        }

        public async Task<IEnumerable<Livro>> ListarLivros()
        {
            var livros = Context.Livros
                .Include(x => x.Autor)
                .Include(x => x.Editora)
                .AsNoTracking();
            return await Task.FromResult(Mapper.Map<IEnumerable<Livro>>(livros));
        }

        public async Task<Livro> BuscarLivroPorId(Guid id)
        {
            var livro = await Context.Livros.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (livro == null)
                Notifier.AdicionarErro(NomeEntidade, LivroNaoEncontrada, System.Net.HttpStatusCode.NotFound);

            return Mapper.Map<Livro>(livro);
        }

        public async Task<Livro> InserirLivro(Livro livro)
        {
            var livroView = Mapper.Map<LivroView>(livro);
            livroView.Id = Guid.NewGuid();
            var resultado = await Context.AddAsync(livroView);
            await Context.SaveChangesAsync();
            return Mapper.Map<Livro>(resultado.Entity);
        }

        public async Task<Livro> AtualizarLivro(Livro livro)
        {
            var atual = await BuscarLivroPorId(livro.Id);
            if (atual == null) return null;
            
            var livroView = Mapper.Map<LivroView>(livro);
            Context.Update(livroView);
            await Context.SaveChangesAsync();
            return livro;
        }

        public async Task ExcluirLivro(Guid id)
        {
            var livro = await BuscarLivroPorId(id);
            if (Notifier.ExistemErros) return;

            var view = Mapper.Map<LivroView>(livro);
            Context.Livros.Remove(view);
            await Context.SaveChangesAsync();
        }
    }
}