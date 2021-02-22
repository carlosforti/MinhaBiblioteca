using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Livros;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Livros;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Livros
{
    public class ListarLivrosUseCaseTest
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;
        private readonly Mock<ILivroRepository> _livroRepository = new();

        private ListarLivrosUseCase GerarUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            return new ListarLivrosUseCase(_mapper, notificador, _livroRepository.Object);
        }

        [Fact]
        public async Task Executar_DeveRetornarNulo_QuandoNaoEncontrar()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro" , "não encontrado");
            
            var useCase = GerarUseCase(out var notificador);
            _livroRepository
                .Setup(x => x.ListarLivros())
                .ReturnsAsync((IEnumerable<Livro>) null)
                .Callback(() => notificador.AdicionarErro("erro", "não encontrado"));

            var resultado = await useCase.Executar();

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _livroRepository.Verify(x=>x.ListarLivros(), Times.Once);
        }

        [Fact]
        public async Task Executar_DeveRetornarLista_QuandoEncontrar()
        {
            var livros = LivroBogus.GerarListaLivros(3).ToList();
            var esperado = LivroBogus.CriarListaLivroResumidoViewModel(livros);

            _livroRepository
                .Setup(x => x.ListarLivros())
                .ReturnsAsync(livros);

            var useCase = GerarUseCase(out _);

            var resultado = await useCase.Executar();

            resultado.Should().BeEquivalentTo(esperado);
            _livroRepository.Verify(x=>x.ListarLivros(), Times.Once);
        }
    }
}