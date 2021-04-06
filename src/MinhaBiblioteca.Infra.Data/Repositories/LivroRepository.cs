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
    public class LivroRepository : ILivroRepository
    {
        private const string NomeEntidade = "Livro";
        private const string LivroNaoEncontrada = "Livro não encontrado";

        private readonly INotificador _notifier;
        private readonly IMapper _mapper;
        private readonly BibliotecaContext _context;

        public LivroRepository(INotificador notifier, IMapper mapper, BibliotecaContext context)
        {
            _notifier = notifier;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<Livro>> ListarLivros()
        {
            var livros = _context.Livros.AsNoTracking();
            return await Task.FromResult(_mapper.Map<IEnumerable<Livro>>(livros));
        }

        public async Task<Livro> BuscarLivroPorId(Guid id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
                _notifier.AdicionarErro(NomeEntidade, LivroNaoEncontrada, System.Net.HttpStatusCode.NoContent);

            return _mapper.Map<Livro>(livro);
        }

        public async Task<Livro> InserirLivro(Livro livro)
        {
            var livroView = _mapper.Map<LivroView>(livro);
            livroView.Id = Guid.NewGuid();
            var resultado = await _context.AddAsync(livroView);
            await _context.SaveChangesAsync();
            return _mapper.Map<Livro>(resultado.Entity);
        }

        public async Task<Livro> AtualizarLivro(Livro livro)
        {
            var livroView = _mapper.Map<LivroView>(livro);
            _context.Update(livroView);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task ExcluirLivro(Guid id)
        {
            var livro = await BuscarLivroPorId(id);
            if (livro == null) return;

            _context.Remove(livro);
            await _context.SaveChangesAsync();
        }
    }
}