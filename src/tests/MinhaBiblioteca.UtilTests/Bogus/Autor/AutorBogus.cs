using System.Collections.Generic;
using Bogus;

namespace MinhaBiblioteca.UtilTests.Bogus.Autor
{
    public static class AutorBogus
    {
        private static Faker<Domain.Entities.Autor> GerarAutorInternal(int? id = null)
        {
            return new Faker<Domain.Entities.Autor>()
                .CustomInstantiator(faker => new Domain.Entities.Autor(id ?? faker.Random.Int(), faker.Person.FullName,
                    faker.Person.Email, faker.Address.Country()));
        }

        public static Domain.Entities.Autor GerarAutor(int? id = null)
        {
            return GerarAutorInternal(id).Generate();
        }

        public static IEnumerable<Domain.Entities.Autor> GerarAutores(int quantidade = 1)
        {
            return GerarAutorInternal().Generate(quantidade);
        }
    }
}