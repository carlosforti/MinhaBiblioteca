using System.Collections.Generic;
using Bogus;
using MinhaBiblioteca.Application.ViewModels.Editora;

namespace MinhaBiblioteca.UtilTests.Bogus.Editora
{
    public static class EditoraResumidaViewModelBogus
    {
        private static Faker<EditoraResumidaViewModel> GerarEditoraResumidaInternal(int? id = null)
        {
            return new Faker<EditoraResumidaViewModel>()
                .CustomInstantiator(faker => new EditoraResumidaViewModel
                {
                    Id = id ?? faker.Random.Int(),
                    Nome = faker.Company.CompanyName()
                });
        }

        public static EditoraResumidaViewModel GerarEdiitoraResumidaViewModel(int? id = null)
        {
            return GerarEditoraResumidaInternal(id).Generate();
        }

        public static IEnumerable<EditoraResumidaViewModel> GerarEditorasResumidasViewModel(int quantidade = 1)
        {
            return GerarEditoraResumidaInternal().Generate(quantidade);
        }
    }
}