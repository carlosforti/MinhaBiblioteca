using System;
using System.Collections.Generic;
using Bogus;

namespace MinhaBiblioteca.UtilTests.Bogus.Autores
{
    public static class AutorBogus
    {
        private static Faker<Domain.Entities.Autor> GerarAutorInternal(Guid? id = null)
        {
            return new Faker<Domain.Entities.Autor>()
                .CustomInstantiator(faker => new Domain.Entities.Autor(id ?? faker.Random.Guid(), faker.Person.FullName,
                    faker.Person.Email, faker.Address.Country()));
        }

        public static Domain.Entities.Autor GerarAutor(Guid? id = null)
        {
            return GerarAutorInternal(id).Generate();
        }

        public static IEnumerable<Domain.Entities.Autor> GerarAutores(int quantidade = 1)
        {
            return GerarAutorInternal().Generate(quantidade);
        }
    }
}