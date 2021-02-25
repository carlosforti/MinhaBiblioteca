using System.Collections.Generic;
using Bogus;

namespace MinhaBiblioteca.UtilTests.Bogus.Editoras
{
    public static class EditoraBogus
    {
        private static Faker<Domain.Entities.Editora> GerarEditoraInternal(int? id =null)
        {
            return new Faker<Domain.Entities.Editora>()
                .CustomInstantiator(faker => new Domain.Entities.Editora(
                    id ?? faker.Random.Int(),
                    faker.Company.CompanyName(),
                    faker.Person.Email,
                    faker.Address.Country()));
        }

        public static Domain.Entities.Editora GerarEditora(int? id = null)
        {
            return GerarEditoraInternal(id).Generate();
        }

        public static IEnumerable<Domain.Entities.Editora> GerarEditoras(int quantidade = 1)
        {
            return GerarEditoraInternal(null).Generate(quantidade);
        }
    }
}