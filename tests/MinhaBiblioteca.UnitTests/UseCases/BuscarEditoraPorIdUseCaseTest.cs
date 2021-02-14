using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.CrossCutting.Notificacoes;
using FluentAssertions;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.UseCases
{
    public class BuscarEditotaPorIdUseCaseTest
    {
        [Fact]
        public async Task BuscarEditoraPorId_DeveRetornarComSucesso()
        {
            var notificador = new Notificador();
            var editora = new Editora(10, "Editora Fake", "contato@editorafake.com.br", "Brasil");
            var query = new Mock<IEditoraQuery>();
            query.Setup(x => x.BuscarEditora(It.IsAny<int>()))
                .ReturnsAsync(editora);

            var useCase = new BuscarEditoraPorIdUseCase(query.Object, notificador);
            var resultado = await useCase.Executar(10);

            resultado.Should().Be(editora);
        }

        [Fact]
        public async Task BuscarEditoraPorId_DeveRetornarNulo_ENotificar()
        {
            var notificador = new Notificador();
            var query = new Mock<IEditoraQuery>();
            query.Setup(x => x.BuscarEditora(It.IsAny<int>()))
                .Callback(() => notificador.AdicionarErro("editora", "Não Encontrada"));

            var useCase = new BuscarEditoraPorIdUseCase(query.Object, notificador);
            var resultado = await useCase.Executar(100);

            resultado.Should().BeNull();
            notificador.TemErros.Should().BeTrue();
        }
    }
}
