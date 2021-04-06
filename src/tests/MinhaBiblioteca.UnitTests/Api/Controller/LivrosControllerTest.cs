using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.API.Controllers;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.UseCases.Livros.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Application.ViewModels.Livros;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Livros;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Api.Controller
{
    public class LivrosControllerTest
    {
        private readonly IResponseFormatter _responseFormatter;
        private readonly Notificador _notificador = new();
        private readonly Mock<IInserirLivroUseCase> _inserirLivroUseCase;
        private readonly Mock<IBuscarLivroPorIdUseCase> _buscarLivroPorIdUseCase;
        private readonly Mock<IListarLivrosUseCase> _listarLivrosUseCase;
        private readonly Mock<IAtualizarLivroUseCase> _atualizarLivroUseCase;
        private readonly Mock<IExcluirLivroUseCase> _excluirLivroUsecase;
        private readonly LivrosController _controller;

        public LivrosControllerTest()
        {
            _inserirLivroUseCase = new Mock<IInserirLivroUseCase>();
            _buscarLivroPorIdUseCase = new Mock<IBuscarLivroPorIdUseCase>();
            _listarLivrosUseCase = new Mock<IListarLivrosUseCase>();
            _atualizarLivroUseCase = new Mock<IAtualizarLivroUseCase>();
            _excluirLivroUsecase = new Mock<IExcluirLivroUseCase>();

            _responseFormatter = new ResponseFormatter(_notificador);

            _controller = new LivrosController(
                _responseFormatter,
                _listarLivrosUseCase.Object,
                _buscarLivroPorIdUseCase.Object,
                _inserirLivroUseCase.Object,
                _atualizarLivroUseCase.Object,
                _excluirLivroUsecase.Object);
        }

        [Fact]
        public async Task GET_DeveRetornarItemUnico()
        {
            var id = Guid.NewGuid();
            var livroViewModel = LivroViewModelBogus.GerarLivroViewModel(id);
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Get, livroViewModel) as OkObjectResult;

            _buscarLivroPorIdUseCase
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(livroViewModel);

            var resultado = (await _controller.Get(id)) as OkObjectResult;

            (resultado.Value as EditoraViewModel).Should()
                .BeEquivalentTo((esperado.Value as EditoraViewModel));
            _buscarLivroPorIdUseCase.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task GET_DeveRetornarLista()
        {
            var livrosViewModel = LivroViewModelBogus
                .GerarLivrossResumidosViewModel(3)
                .ToList();

            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Get, livrosViewModel) as OkObjectResult;

            _listarLivrosUseCase
                .Setup(x => x.Executar())
                .ReturnsAsync(livrosViewModel);

            var resultado = await _controller.Get() as OkObjectResult;

            (resultado.Value as Response<IEnumerable<EditoraResumidaViewModel>>)
                .Should().BeEquivalentTo(esperado.Value as Response<IEnumerable<EditoraResumidaViewModel>>);
            _listarLivrosUseCase.Verify(x => x.Executar(), Times.Once);
        }

        [Fact]
        public async Task POST_DeveExecutar()
        {
            var livroViewModel = LivroViewModelBogus.GerarLivroViewModel();
            var esperado =
                _responseFormatter.FormatarResposta(TipoRequisicao.Post, livroViewModel) as CreatedResult;

            var entrada = new InserirLivroViewModel
            {
                Nome = livroViewModel.Nome,
                Edicao = livroViewModel.Edicao,
                EditoraId = livroViewModel.Editora.Id,
                AutorId = livroViewModel.Autor.Id
            };

            _inserirLivroUseCase
                .Setup(x => x.Executar(It.IsAny<InserirLivroViewModel>()))
                .ReturnsAsync(livroViewModel);

            var resultado = (await _controller.Post(entrada)) as CreatedResult;

            (resultado.Value as Response<EditoraViewModel>)
                .Should().BeEquivalentTo(esperado.Value as EditoraViewModel);
            _inserirLivroUseCase
                .Verify(x => x.Executar(It.IsAny<InserirLivroViewModel>()),
                    Times.Once);
        }

        [Fact]
        public async Task PATH_DeveExecutar()
        {
            var livroViewModel = LivroViewModelBogus.GerarLivroViewModel();
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Patch, livroViewModel);

            var entrada = new AtualizarLivroViewModel
            {
                Id = livroViewModel.Id,
                Nome = livroViewModel.Nome,
                Edicao = livroViewModel.Edicao,
                EditoraId = livroViewModel.Editora.Id,
                AutorId = livroViewModel.Autor.Id
            };

            _atualizarLivroUseCase
                .Setup(x => x.Executar(It.IsAny<Guid>(),
                    It.IsAny<AtualizarLivroViewModel>()))
                .ReturnsAsync(livroViewModel);

            var resultado = await _controller.Put(livroViewModel.Id, entrada);

            ((AcceptedResult) resultado).Value
                .Should().BeEquivalentTo(((AcceptedResult) esperado).Value);
            _atualizarLivroUseCase
                .Verify(x => x.Executar(It.IsAny<Guid>(),
                    It.IsAny<AtualizarLivroViewModel>()), Times.Once);
        }

        [Fact]
        public async Task DELETE_DeveExecutar()
        {
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Delete, null);

            _excluirLivroUsecase
                .Setup(x => x.Executar(It.IsAny<Guid>()));

            var resultado = await _controller.Delete(Guid.NewGuid());

            resultado.Should().NotBeNull();
            ((NoContentResult) resultado).Should().BeEquivalentTo((NoContentResult) esperado);
            _excluirLivroUsecase
                .Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }
    }
}