using System.Collections.Generic;
using System.Linq;
using Bogus;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.UtilTests.Bogus.Autores
{
    public static class AutorResumidoViewModelBogus
    {
        private static Faker<AutorResumidoViewModel> GerarAutorResumidoInternal(int? id = null)
        {
            return new Faker<AutorResumidoViewModel>()
                .CustomInstantiator(faker =>
                    new AutorResumidoViewModel
                    {
                        Id = id ?? faker.Random.Int(),
                        Nome = faker.Person.FullName
                    });
        }

        public static AutorResumidoViewModel ConverterDeAutor(Domain.Entities.Autor autor) =>
            new AutorResumidoViewModel
            {
                Id = autor.Id,
                Nome = autor.Nome
            };

        public static IEnumerable<AutorResumidoViewModel> ConverterListaDeAutores(
            IEnumerable<Domain.Entities.Autor> autores) =>
            autores.Select(ConverterDeAutor);

        public static AutorResumidoViewModel ConverterAutorParaViewModel(Autor autor) =>
            new AutorResumidoViewModel
            {
                Id = autor.Id,
                Nome = autor.Nome
            };

        public static AutorResumidoViewModel GerarAutorResumidoViewModel(int? id = null)
        {
            return GerarAutorResumidoInternal(id).Generate();
        }

        public static IEnumerable<AutorResumidoViewModel> GerarAutoresResumidosViewModel(int quantidade = 1)
        {
            return GerarAutorResumidoInternal().Generate(quantidade);
        }
    }
}