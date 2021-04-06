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
    public class InserirLivroUseCaseTest
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;
        private readonly Mock<ILivroRepository> _livroRepository = new();
        private readonly Mock<IBuscarAutorPorIdUseCase> _buscarAutor = new();
        private readonly Mock<IBuscarEditoraPorIdUseCase> _buscarEditora = new();
        private readonly EditoraViewModel _editoraViewModel = EditoraViewModelBogus.GerarEditoraViewModel();
        private readonly AutorViewModel _autorViewModel = AutorViewModelBogus.GerarAutorViewModel();
        private readonly InserirLivroViewModel _inserirLivroViewModel;
        
        public InserirLivroUseCaseTest()
        {
            _inserirLivroViewModel = new InserirLivroViewModel
            {
                Nome = "Livro",
                Edicao = 1,
                AutorId = _autorViewModel.Id,
                EditoraId = _editoraViewModel.Id
            };
        }
        
        private InserirLivroUseCase GerarUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            return new InserirLivroUseCase(_mapper,
                notificador,
                _livroRepository.Object,
                _buscarEditora.Object,
                _buscarAutor.Object);
        }

        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotificar_QuandoNaoEncontrarEditora()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");
            
            var useCase = GerarUseCase(out var notificador);

            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync((EditoraViewModel) null)
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(_autorViewModel);

            var resultado = await useCase.Executar(_inserirLivroViewModel);

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _buscarAutor.Verify(x=>x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x=>x.Executar(It.IsAny<Guid>()), Times.Once);
            _livroRepository.Verify(x => x.InserirLivro(It.IsAny<Livro>()), Times.Never);
        }
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotificar_QuandoNaoEncontrarAutor()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");
            
            var useCase = GerarUseCase(out var notificador);

            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(_editoraViewModel);

            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync((AutorViewModel) null)
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            var resultado = await useCase.Executar(_inserirLivroViewModel);

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _buscarAutor.Verify(x=>x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x=>x.Executar(It.IsAny<Guid>()), Times.Once);
            _livroRepository.Verify(x => x.InserirLivro(It.IsAny<Livro>()), Times.Never);
        }
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_QuandoOcorrerErroAoInserir()
        {
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var useCase = GerarUseCase(out var notificador);
            
            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(_editoraViewModel);

            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(_autorViewModel);
            
            _livroRepository
                .Setup(x => x.InserirLivro(It.IsAny<Livro>()))
                .ReturnsAsync((Livro) null)
                .Callback(() => notificador.AdicionarErro("erro", "mensagem"));

            var resultado = await useCase.Executar(_inserirLivroViewModel);
            
            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
            _buscarAutor.Verify(x=>x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x=>x.Executar(It.IsAny<Guid>()), Times.Once);
            _livroRepository.Verify(x => x.InserirLivro(It.IsAny<Livro>()), Times.Once);
        }
        
        [Fact]
        public async Task Executar_DeveRetornar_QuandoSucesso()
        {
            var livro = _mapper.Map<Livro>((_inserirLivroViewModel, _editoraViewModel, _autorViewModel));
            var esperado = LivroBogus.CriarLivroViewModel(livro);
            
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("erro", "mensagem");

            var useCase = GerarUseCase(out var notificador);
            
            _buscarEditora
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(_editoraViewModel);

            _buscarAutor
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(_autorViewModel);
            
            _livroRepository
                .Setup(x => x.InserirLivro(It.IsAny<Livro>()))
                .ReturnsAsync(livro);

            var resultado = await useCase.Executar(_inserirLivroViewModel);

            resultado.Should().BeEquivalentTo(esperado);
            _buscarAutor.Verify(x=>x.Executar(It.IsAny<Guid>()), Times.Once);
            _buscarEditora.Verify(x=>x.Executar(It.IsAny<Guid>()), Times.Once);
            _livroRepository.Verify(x => x.InserirLivro(It.IsAny<Livro>()), Times.Once);
        }
    }
}