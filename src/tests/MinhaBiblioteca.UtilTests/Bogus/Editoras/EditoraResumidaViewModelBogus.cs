using System;
using System.Collections.Generic;
using Bogus;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.UtilTests.Bogus.Editoras
{
    public static class EditoraResumidaViewModelBogus
    {
        private static Faker<EditoraResumidaViewModel> GerarEditoraResumidaInternal(Guid? id = null) =>
            new Faker<EditoraResumidaViewModel>()
                .CustomInstantiator(faker => new EditoraResumidaViewModel
                {
                    Id = id ?? faker.Random.Guid(),
                    Nome = faker.Company.CompanyName()
                });

        public static EditoraResumidaViewModel GerarEdiitoraResumidaViewModel(Guid? id = null) => 
            GerarEditoraResumidaInternal(id).Generate();

        public static IEnumerable<EditoraResumidaViewModel> GerarEditorasResumidasViewModel(int quantidade = 1) => 
            GerarEditoraResumidaInternal().Generate(quantidade);

        public static EditoraResumidaViewModel ConverterEditoraParaViewModel(Editora editora) =>
            new EditoraResumidaViewModel
            {
                Id = editora.Id,
                Nome = editora.Nome
            };
    }
}