using System;
using System.Threading.Tasks;

using AutoMapper;

using FluentAssertions;

using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.UseCases.Livros;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Autores;
using MinhaBiblioteca.UtilTests.Bogus.Editoras;
using MinhaBiblioteca.UtilTests.Bogus.Livros;
using MinhaBiblioteca.UtilTests.Mapeamento;

using Moq;

using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Livros
{
    public class AtualizarLivroUseCaseTest
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;
        private readonly Mock<ILivroRepository> _livroRepository = new();
        private readonly Mock<IBuscarEditoraPorIdUseCase> _buscarEditora = new();
        private readonly Mock<IBuscarAutorPorIdUseCase> _buscarAutor = new();

        private AtualizarLivroUseCase GerarUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            var useCase = new AtualizarLivroUseCase(_mapper,
                                                    notificador,
                                                    _livroRepository.Object,
                                                    _buscarEditora.Object,
                                                    _buscarAutor.Object);
            return useCase;
        }

        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotificar_QuandoIdDiferenteNaRotaEBody()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("id", "Id informado não corresponde ao da rota");

            var livro = LivroBogus.GerarLivro(Guid.NewGuid());
            var atualizarLivroViewModel = LivroBogus.CriarAtualizarLivroViewModelDeLivro(livro);
            var useCase = GerarUseCase(out var notificador);

            var resultado = await useCase.Executar(Guid.NewGuid(), atualizarLivroViewModel);

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _livroRepository.Verify(x => x.AtualizarLivro(It.IsAny<Livro>()), Times.Never);
            _buscarAutor.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Never);
            _buscarEditora.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task Executar_DeveNotificar_QuandoOcorrerUmErro()
        {
            var id = Guid.NewGuid();
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var livro = LivroBogus.GerarLivro(id);
            var atualizarLivroViewModel = LivroBogus.CriarAtualizarLivroViewModelDeLivro(livro);

            var autor = AutorViewModelBogus.ConverterDeAutor(livro.Autor);
            var editora = EditoraViewModelBogus.ConverterEditoraParaViewModel(livro.Editora);
            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(autor);

            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(editora);

            var useCase = GerarUseCase(out var notificador);
            _livroRepository
                .Setup(x => x.AtualizarLivro(It.IsAny<Livro>()))
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            var resultado = await useCase.Executar(id, atualizarLivroViewModel);

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _livroRepository.Verify(x => x.AtualizarLivro(It.IsAny<Livro>()), Times.Once);
            _buscarAutor.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Executar_DeveNotificar_QuandoOcorrerUmErro_NaBuscaDeAutor()
        {
            var id = Guid.NewGuid();
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var livro = LivroBogus.GerarLivro(id);
            var atualizarLivroViewModel = LivroBogus.CriarAtualizarLivroViewModelDeLivro(livro);

            var useCase = GerarUseCase(out var notificador);

            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            var resultado = await useCase.Executar(id, atualizarLivroViewModel);

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _livroRepository.Verify(x => x.AtualizarLivro(It.IsAny<Livro>()), Times.Never);
            _buscarAutor.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Executar_DeveNotificar_QuandoOcorrerUmErro_NaBuscaDeEditora()
        {
            var id = Guid.NewGuid();
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var livro = LivroBogus.GerarLivro(id);
            var atualizarLivroViewModel = LivroBogus.CriarAtualizarLivroViewModelDeLivro(livro);

            var useCase = GerarUseCase(out var notificador);

            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            var resultado = await useCase.Executar(id, atualizarLivroViewModel);

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _livroRepository.Verify(x => x.AtualizarLivro(It.IsAny<Livro>()), Times.Never);
            _buscarAutor.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Executar_DeveRetornarNulo_QuandoNaoEncontrarEditora()
        {
            var id = Guid.NewGuid();

            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var livro = LivroBogus.GerarLivro(id);
            var atualizarLivroViewModel = LivroBogus.CriarAtualizarLivroViewModelDeLivro(livro);

            var useCase = GerarUseCase(out var notificador);

            var autor = AutorViewModelBogus.ConverterDeAutor(livro.Autor);
            var editora = EditoraViewModelBogus.ConverterEditoraParaViewModel(livro.Editora);
            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(null as EditoraViewModel);
            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(autor);

            var resultado = await useCase.Executar(id, atualizarLivroViewModel);

            resultado.Should().BeNull();
            _livroRepository.Verify(x => x.AtualizarLivro(It.IsAny<Livro>()), Times.Never);
            _buscarAutor.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Executar_DeveRetornarNulo_QuandoNaoEncontrarAutor()
        {
            var id = Guid.NewGuid();
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var livro = LivroBogus.GerarLivro(id);
            var atualizarLivroViewModel = LivroBogus.CriarAtualizarLivroViewModelDeLivro(livro);
            var useCase = GerarUseCase(out var notificador);

            var autor = AutorViewModelBogus.ConverterDeAutor(livro.Autor);
            var editora = EditoraViewModelBogus.ConverterEditoraParaViewModel(livro.Editora);
            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(editora);
            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(null as AutorViewModel);

            var resultado = await useCase.Executar(id, atualizarLivroViewModel);

            resultado.Should().BeNull();
            _livroRepository.Verify(x => x.AtualizarLivro(It.IsAny<Livro>()), Times.Never);
            _buscarAutor.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Executar_DeveRetornarLivro_QuandoSucesso()
        {
            var id = Guid.NewGuid();
            var livro = LivroBogus.GerarLivro(id);
            var autor = AutorViewModelBogus.ConverterDeAutor(livro.Autor);
            var editora = EditoraViewModelBogus.ConverterEditoraParaViewModel(livro.Editora);

            var atualizarLivroViewModel = LivroBogus.CriarAtualizarLivroViewModelDeLivro(livro);

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

            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(autor);

            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(editora);

            var resultado = await useCase.Executar(id, atualizarLivroViewModel);

            resultado.Should().BeEquivalentTo(esperado);
            _livroRepository.Verify(x => x.AtualizarLivro(It.IsAny<Livro>()), Times.Once);
            _buscarAutor.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }
    }
}