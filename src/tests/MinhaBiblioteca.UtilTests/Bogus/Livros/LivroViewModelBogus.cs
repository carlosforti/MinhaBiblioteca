using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.UtilTests.Bogus.Autores;
using MinhaBiblioteca.UtilTests.Bogus.Editoras;

namespace MinhaBiblioteca.UtilTests.Bogus.Livros
{
    public class LivroViewModelBogus
    {
        private static Faker<LivroViewModel> GerarLivroViewModelInternal(int? id = null) =>
            new Faker<LivroViewModel>()
                .CustomInstantiator(faker =>
                    new LivroViewModel
                    {
                        Id = id ?? faker.Random.Int(),
                        Nome = faker.Random.String2(20),
                        Edicao = faker.Random.Int(),
                        Autor = AutorViewModelBogus.GerarAutorResumidoViewModel(),
                        Editora = EditoraViewModelBogus.GerarEditoraResumidaViewModel()
                    });

        public static LivroViewModel GerarLivroViewModel(int? id = null) =>
            GerarLivroViewModelInternal(id).Generate();

        public static IEnumerable<LivroViewModel> GerarListaLivroViewModel(int quantidade = 1) =>
            GerarLivroViewModelInternal().Generate(quantidade);

        public static IEnumerable<LivroResumidoViewModel> GerarLivrossResumidosViewModel(int quantidade = 1) =>
            GerarListaLivroViewModel(quantidade)
                .Select(livro => new LivroResumidoViewModel
                {
                    Id = livro.Id,
                    Nome = livro.Nome,
                    Edicao = livro.Edicao,
                    NomeAutor = livro.Autor.Nome,
                    NomeEditora = livro.Editora.Nome
                });
    }
}