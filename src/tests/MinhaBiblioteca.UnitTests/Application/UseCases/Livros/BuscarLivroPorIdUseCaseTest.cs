using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Livros;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Livros;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Livros
{
    public class BuscarLivroPorIdUseCaseTest
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;
        private readonly Mock<ILivroRepository> _livroRepository = new();

        private BuscarLivroPorIdUseCase GerarUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            return new BuscarLivroPorIdUseCase(_mapper, notificador, _livroRepository.Object);
        }

        [Fact]
        public async Task Executar_DeveRetornarNuloENotificar_EmCasoDeErro()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var useCase = GerarUseCase(out var notificador);
            _livroRepository
                .Setup(x => x.BuscarLivroPorId(It.IsAny<Guid>()))
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            var resultado = await useCase.Executar(Guid.NewGuid());

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _livroRepository.Verify(x => x.BuscarLivroPorId(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Executar_DeveRetornarNulo_QuandoNaoEncontrar()
        {
            var useCase = GerarUseCase(out var notificador);
            _livroRepository
                .Setup(x => x.BuscarLivroPorId(It.IsAny<Guid>()))
                .ReturnsAsync(null as Livro);

            var resultado = await useCase.Executar(Guid.NewGuid());

            resultado.Should().BeNull();
            _livroRepository.Verify(x => x.BuscarLivroPorId(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Executar_DeveRetornarLivro()
        {
            var id = Guid.NewGuid();
            var livro = LivroBogus.GerarLivro(id);
            _livroRepository
                .Setup(x => x.BuscarLivroPorId(It.IsAny<Guid>()))
                .ReturnsAsync(livro);

            var esperado = new LivroViewModel
            {
                Id = livro.Id,
                Nome = livro.Nome,
                Edicao = livro.Edicao,
                Autor = new AutorResumidoViewModel
                {
                    Id = livro.Autor.Id,
                    Nome = livro.Autor.Nome
                },
                Editora = new EditoraResumidaViewModel
                {
                    Id = livro.Editora.Id,
                    Nome = livro.Editora.Nome
                }
            };

            var useCase = GerarUseCase(out var notificador);
            var resultado = await useCase.Executar(id);

            resultado.Should().BeEquivalentTo(esperado);
            _livroRepository.Verify(x => x.BuscarLivroPorId(It.IsAny<Guid>()), Times.Once);
        }
    }
}