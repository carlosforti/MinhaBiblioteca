using System.Collections.Generic;
using Bogus;
using MinhaBiblioteca.Application.ViewModels.Editoras;

namespace MinhaBiblioteca.UtilTests.Bogus.Editoras
{
    public static class EditoraViewModelBogus
    {
        private static Faker<EditoraViewModel> GerarEditoraViewModelInternal(int? id = null)
        {
            return new Faker<EditoraViewModel>()
                .CustomInstantiator(faker => new EditoraViewModel
                {
                    Id = id ?? faker.Random.Int(),
                    Nome = faker.Company.CompanyName(),
                    Email = faker.Person.Email,
                    Pais = faker.Address.Country()
                });
        }

        public static IEnumerable<EditoraViewModel> GerarEditorasViewModel(int quantidade = 1)
        {
            return GerarEditoraViewModelInternal().Generate(quantidade);
        }

        public static EditoraViewModel GerarEditoraViewModel(int? id = null)
        {
            return GerarEditoraViewModelInternal(id).Generate();
        }

        public static EditoraViewModel ConverterEditoraParaViewModel(Domain.Entities.Editora editora)
        {
            return new EditoraViewModel
            {
                Id = editora.Id,
                Nome = editora.Nome,
                Email = editora.Email,
                Pais = editora.Pais
            };
        }
    }
}