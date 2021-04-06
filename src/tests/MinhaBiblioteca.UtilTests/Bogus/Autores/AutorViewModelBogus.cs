using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using MinhaBiblioteca.Application.ViewModels.Autores;

namespace MinhaBiblioteca.UtilTests.Bogus.Autores
{
    public static class AutorViewModelBogus
    {
        private static Faker<AutorViewModel> GerarAutorViewModelInternal(Guid? id = null) =>
            new Faker<AutorViewModel>()
                .CustomInstantiator(faker => new AutorViewModel
                {
                    Id = id ?? faker.Random.Guid(),
                    Nome = faker.Person.FullName,
                    Email = faker.Person.Email,
                    Pais = faker.Address.Country()
                });

        public static AutorViewModel GerarAutorViewModel(Guid? id = null) =>
            GerarAutorViewModelInternal(id).Generate();

        public static IEnumerable<AutorViewModel> GerarAutoresViewModel(int quantidade = 1) =>
            GerarAutorViewModelInternal().Generate(quantidade);

        public static AutorViewModel ConverterDeAutor(Domain.Entities.Autor autor) =>
            new AutorViewModel
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Email = autor.Email,
                Pais = autor.Pais
            };

        public static IEnumerable<AutorViewModel> ConverterListaDeAutores(IEnumerable<Domain.Entities.Autor> autores)
        {
            return autores.Select(ConverterDeAutor);
        }

        public static AutorResumidoViewModel GerarAutorResumidoViewModel()
        {
            var autor = GerarAutorViewModel();
            return new AutorResumidoViewModel
            {
                Id = autor.Id,
                Nome = autor.Nome
            };
        }
    }
}