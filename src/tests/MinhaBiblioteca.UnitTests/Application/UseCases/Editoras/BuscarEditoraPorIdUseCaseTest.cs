using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Editoras
{
    public class BuscarEditotaPorIdUseCaseTest
    {
        [Fact]
        public async Task BuscarEditoraPorId_DeveRetornarComSucesso()
        {
            var newId = Guid.NewGuid();
            var mapper = new Mock<IMapper>();
            var notificador = new Notificador();
            var editora = new Domain.Entities.Editora(newId, "Editora Fake", "contato@editorafake.com.br", "Brasil");
            var editoraViewModel = new EditoraViewModel
            {
                Id = editora.Id,
                Nome = editora.Nome,
                Email = editora.Email,
                Pais = editora.Pais
            };

            var query = new Mock<IEditoraRepository>();
            query.Setup(x => x.BuscarEditoraPorId(It.IsAny<Guid>()))
                .ReturnsAsync(editora);
            mapper.Setup(x => x.Map<EditoraViewModel>(It.IsAny<Domain.Entities.Editora>()))
                .Returns(editoraViewModel);

            var useCase = new BuscarEditoraPorIdUseCase(query.Object, notificador, mapper.Object);
            var resultado = await useCase.Executar(newId);

            resultado.Should().Be(editoraViewModel);
        }

        [Fact]
        public async Task BuscarEditoraPorId_DeveRetornarNulo_ENotificar()
        {
            var mapper = new Mock<IMapper>();
            var notificador = new Notificador();
            var query = new Mock<IEditoraRepository>();
            query.Setup(x => x.BuscarEditoraPorId(It.IsAny<Guid>()))
                .Callback(() => notificador.AdicionarErro("editora", "Não Encontrada"));

            var useCase = new BuscarEditoraPorIdUseCase(query.Object, notificador, mapper.Object);
            var resultado = await useCase.Executar(Guid.NewGuid());

            resultado.Should().BeNull();
            notificador.ExistemErros.Should().BeTrue();
        }
    }
}