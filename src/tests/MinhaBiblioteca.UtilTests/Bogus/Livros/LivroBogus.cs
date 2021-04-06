using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.UtilTests.Bogus.Autores;
using MinhaBiblioteca.UtilTests.Bogus.Editoras;

namespace MinhaBiblioteca.UtilTests.Bogus.Livros
{
    public static class LivroBogus
    {
        private static Faker<Livro> GerarLivroInternal(Guid? id = null, bool criarEditora = true, bool criarAutor = true)
        {
            return new Faker<Livro>()
                .CustomInstantiator(faker =>
                {
                    var autor = criarAutor ? AutorBogus.GerarAutor() : null;
                    var editora = criarEditora ? EditoraBogus.GerarEditora() : null;
                    return new Livro(
                        id ?? faker.Random.Guid(),
                        faker.Lorem.Slug(),
                        faker.Random.Int(1, 10),
                        autor,
                        editora
                    );
                });
        }

        public static Livro GerarLivro(Guid? id = null, bool criarEditora = true, bool criarAutor = true) =>
            GerarLivroInternal(id, criarEditora, criarAutor).Generate();

        public static IEnumerable<Livro> GerarListaLivros(int quantidade = 1)
            => GerarLivroInternal().Generate(quantidade);

        public static AtualizarLivroViewModel CriarAtualizarLivroViewModelDeLivro(Livro livro) =>
            new AtualizarLivroViewModel
            {
                Id = livro.Id,
                Nome = livro.Nome,
                Edicao = livro.Edicao,
                AutorId = livro.Autor?.Id ?? Guid.Empty,
                EditoraId = livro.Editora?.Id ?? Guid.Empty,
            };

        public static IEnumerable<LivroResumidoViewModel> CriarListaLivroResumidoViewModel(IEnumerable<Livro> livros) =>
            livros.Select(CriarLivroResumidoViewModel);

        public static LivroResumidoViewModel CriarLivroResumidoViewModel(Livro livro) =>
            new LivroResumidoViewModel
            {
                Id = livro.Id,
                Nome = livro.Nome,
                Edicao = livro.Edicao,
                NomeAutor = livro.Autor.Nome,
                NomeEditora = livro.Editora.Nome
            };

        public static LivroViewModel CriarLivroViewModel(Livro livro) =>
            new LivroViewModel
            {
                Id = livro.Id,
                Nome = livro.Nome,
                Edicao = livro.Edicao,
                Editora = EditoraResumidaViewModelBogus.ConverterEditoraParaViewModel(livro.Editora),
                Autor = AutorResumidoViewModelBogus.ConverterAutorParaViewModel(livro.Autor)
            };
    }
}