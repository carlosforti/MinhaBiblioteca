using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus;
using MinhaBiblioteca.UtilTests.Bogus.Autor;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Autor
{
    public class ListarAutoresUseCaseTest
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;
        private readonly Mock<IAutorRepository> _autorRepository = new();

        private ListarAutoresUseCase GerarUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            return new ListarAutoresUseCase(_mapper, _autorRepository.Object, notificador);
        }

        [Fact]
        public async Task Executar_DeveRetornarVazio_QuandoOcorrerErro()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");
            
            var useCase = GerarUseCase(out var notificador);
            _autorRepository
                .Setup(x => x.ListarAutores())
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            var resultado = await useCase.Executar();

            resultado.Should().BeEmpty();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }

        [Fact]
        public async Task Executar_DeveRetornarVazio_QuandoNaoEncontrarAutores()
        {
            _autorRepository
                .Setup(x => x.ListarAutores())
                .ReturnsAsync(new List<Domain.Entities.Autor>());

            var useCase = GerarUseCase(out var notificador);

            var resultado = await useCase.Executar();

            resultado.Should().BeEmpty();
            notificador.TemErros.Should().BeFalse();
        }

        [Fact]
        public async Task Executar_DeveRetornarLista()
        {
            var autores = AutorBogus.GerarAutores(3).ToList();
            var esperado = AutorResumidoViewModelBogus.ConverterListaDeAutores(autores);

            _autorRepository
                .Setup(x => x.ListarAutores())
                .ReturnsAsync(autores);

            var useCase = GerarUseCase(out var notificador);

            var resultado = await useCase.Executar();

            resultado.Should().BeEquivalentTo(esperado);
            resultado.Count().Should().Be(3);
            notificador.TemErros.Should().BeFalse();
        }
    }
}