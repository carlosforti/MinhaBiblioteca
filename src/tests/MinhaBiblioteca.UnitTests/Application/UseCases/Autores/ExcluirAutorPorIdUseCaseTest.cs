using System;
using System.Threading.Tasks;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Autores
{
    public class ExcluirAutorPorIdUseCaseTest
    {
        private readonly Mock<IAutorRepository> _autorRepository = new Mock<IAutorRepository>();

        private ExcluirAutorUseCase GerarUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            return new ExcluirAutorUseCase(notificador, _autorRepository.Object);
        }

        [Fact]
        public async Task Executar_DeveNotificarErro()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var useCase = GerarUseCase(out var notificador);

            _autorRepository
                .Setup(x => x.ExcluirAutor(It.IsAny<Guid>()))
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            await useCase.Executar(Guid.NewGuid());
            
            _autorRepository.Verify(x => x.ExcluirAutor(It.IsAny<Guid>()), Times.Once);
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }

        [Fact]
        public async Task Executar_DeveSeguir_QuandoNaoOcorrerErro()
        {
            var useCase = GerarUseCase(out var notificador);

            _autorRepository.Setup(x => x.ExcluirAutor(It.IsAny<Guid>()));

            await useCase.Executar(Guid.NewGuid());
            
            _autorRepository.Verify(x => x.ExcluirAutor(It.IsAny<Guid>()), Times.Once);
            notificador.ExistemErros.Should().BeFalse();
        }
    }
}