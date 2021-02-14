using System.Threading.Tasks;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Autor
{
    public class ExcluirAutorPorIdUseCaseTest
    {
        private readonly Mock<IAutorRepository> _autorRepository = new Mock<IAutorRepository>();

        private ExcluirAutorPorIdUseCase GerarUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            return new ExcluirAutorPorIdUseCase(notificador, _autorRepository.Object);
        }

        [Fact]
        public async Task Executar_DeveNotificarErro()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var useCase = GerarUseCase(out var notificador);

            _autorRepository
                .Setup(x => x.ExcluirAutor(It.IsAny<int>()))
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            await useCase.Executar(1);
            
            _autorRepository.Verify(x => x.ExcluirAutor(It.IsAny<int>()), Times.Once);
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }

        [Fact]
        public async Task Executar_DeveSeguir_QuandoNaoOcorrerErro()
        {
            var useCase = GerarUseCase(out var notificador);

            _autorRepository.Setup(x => x.ExcluirAutor(It.IsAny<int>()));

            await useCase.Executar(1);
            
            _autorRepository.Verify(x => x.ExcluirAutor(It.IsAny<int>()), Times.Once);
            notificador.TemErros.Should().BeFalse();
        }
    }
}