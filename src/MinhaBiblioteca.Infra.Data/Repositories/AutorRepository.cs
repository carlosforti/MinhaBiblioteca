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
    public class AutorRepository : IAutorRepository
    {
        private const string NomeEntidade = "Autor";
        private const string AutorNaoEncontrado = "Autor Não Encontrado";

        private readonly IMapper _mapper;
        private readonly BibliotecaContext _context;
        private readonly INotificador _notificador;

        public AutorRepository(BibliotecaContext context, INotificador notificador, IMapper mapper)
        {
            _context = context;
            _notificador = notificador;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Autor>> ListarAutores()
        {
            var autores = _context.Autores.AsNoTracking();
            return await Task.FromResult(_mapper.Map<IEnumerable<Autor>>(autores));
        }

        public async Task<Autor> BuscarAutorPorId(Guid id)
        {
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);
                if (autor == null)
                    _notificador.AdicionarErro(NomeEntidade,
                        AutorNaoEncontrado,
                        System.Net.HttpStatusCode.NoContent);

                return _mapper.Map<Autor>(autor);
            }
            catch (Exception ex)
            {
                _notificador.AdicionarErro(NomeEntidade, ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task<Autor> InserirAutor(Autor autor)
        {
            try
            {
                var view = _mapper.Map<AutorView>(autor);
                view.Id = Guid.NewGuid();
                var resultado = await _context.Autores.AddAsync(view);
                await _context.SaveChangesAsync();

                return _mapper.Map<Autor>(resultado.Entity);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                _notificador.AdicionarErro(NomeEntidade, ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return null;
            }
        }

        public async Task ExcluirAutor(Guid id)
        {
            var autor = await BuscarAutorPorId(id);
            if (_notificador.ExistemErros) return;

            _context.Autores.Remove(_mapper.Map<AutorView>(autor));
            await _context.SaveChangesAsync();
        }
    }
}