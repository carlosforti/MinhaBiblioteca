using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Autores;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Autores
{
    public class BuscarAutorPorIdUseCaseTest
    {
        private IMapper _mapper = AutoMapperHelper.Mapper;
        private Mock<IAutorRepository> _autorRepository = new();

        private BuscarAutorPorIdUseCase GerarUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            return new BuscarAutorPorIdUseCase(_mapper, _autorRepository.Object, notificador);
        }

        [Fact]
        public async Task Executar_DeveNotificarErro()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var useCase = GerarUseCase(out var notificador);

            _autorRepository
                .Setup(x => x.BuscarAutorPorId(It.IsAny<Guid>()))
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            var resultado = await useCase.Executar(Guid.NewGuid());

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }

        [Fact]
        public async Task Executar_DeveRetornarNulo_QuandoNaoEncontrar()
        {
            var useCase = GerarUseCase(out var notificador);

            _autorRepository
                .Setup(x => x.BuscarAutorPorId(It.IsAny<Guid>()))
                .ReturnsAsync(null as Domain.Entities.Autor);

            var resultado = await useCase.Executar(Guid.NewGuid());

            resultado.Should().BeNull();
            notificador.ExistemErros.Should().BeFalse();
        }
        
        [Fact]
        public async Task Executar_DeveRetornarAutor_QuandoEncontrar()
        {
            var autor = AutorBogus.GerarAutor(Guid.NewGuid());
            var esperado = AutorViewModelBogus.ConverterDeAutor(autor);
            
            var useCase = GerarUseCase(out var notificador);

            _autorRepository
                .Setup(x => x.BuscarAutorPorId(It.IsAny<Guid>()))
                .ReturnsAsync(autor);

            var resultado = await useCase.Executar(autor.Id);

            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}