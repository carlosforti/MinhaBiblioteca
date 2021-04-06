using System;
using System.Collections.Generic;
using Bogus;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.UtilTests.Bogus.Autores
{
    public static class AutorViewBogus
    {
        private static Faker<AutorView> CriarAutorViewInternal(Guid? id = null)
        {
            return new Faker<AutorView>()
                .CustomInstantiator(faker => new AutorView()
                {
                    Id = id ?? faker.Random.Guid(),
                    Email = faker.Person.Email,
                    Nome = faker.Person.FullName,
                    Pais = faker.Address.Country()
                });
        }

        public static AutorView GerarAutorView(Guid? id = null) =>
            CriarAutorViewInternal(id).Generate();

        public static IEnumerable<AutorView> GerarAutoresView(int quantidade = 1) =>
            CriarAutorViewInternal().Generate(quantidade);
    }
}