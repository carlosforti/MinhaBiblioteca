using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.API.Controllers;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Autores;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Api.Controller
{
    public class AutoresControllerTest
    {
        private IResponseFormatter _responseFormatter;
        private readonly Mock<IAtualizarAutorUseCase> _atualizarAutorUseCase = new();
        private readonly Mock<IBuscarAutorPorIdUseCase> _buscarAutorPorIdUseCase = new();
        private readonly Mock<IInserirAutorUseCase> _inserirAutorUseCase = new();
        private readonly Mock<IExcluirAutorUseCase> _excluirAutorUseCase = new();
        private readonly Mock<IListarAutoresUseCase> _listarAutoresUseCase = new();

        private AutoresController GerarController(out INotificador notificador)
        {
            notificador = new Notificador();
            _responseFormatter = new ResponseFormatter(notificador);
            return new AutoresController(_responseFormatter,
                _atualizarAutorUseCase.Object,
                _buscarAutorPorIdUseCase.Object,
                _excluirAutorUseCase.Object,
                _inserirAutorUseCase.Object,
                _listarAutoresUseCase.Object);
        }

        [Fact]
        public async Task GET_DeveRetornarItemUnico()
        {
            var id = Guid.NewGuid();
            var controller = GerarController(out _);
            var autorViewModel = AutorViewModelBogus.GerarAutorViewModel(id);
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Get, autorViewModel);

            _buscarAutorPorIdUseCase
                .Setup(x => x.Executar(It.IsAny<Guid>()))
                .ReturnsAsync(autorViewModel);

            var resultado = await controller.Get(id);

            ((OkObjectResult) resultado).Value
                .Should().BeEquivalentTo(((OkObjectResult) esperado).Value);
            _buscarAutorPorIdUseCase.Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task GET_DeveRetornarLista()
        {
            var controller = GerarController(out _);
            var autoresViewModel = AutorResumidoViewModelBogus
                .GerarAutoresResumidosViewModel(3)
                .ToList();

            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Get, autoresViewModel);

            _listarAutoresUseCase
                .Setup(x => x.Executar())
                .ReturnsAsync(autoresViewModel);

            var resultado = await controller.GetAll();

            ((OkObjectResult) resultado).Value
                .Should().BeEquivalentTo(((OkObjectResult) esperado).Value);
        }

        [Fact]
        public async Task POST_DeveExecutar()
        {
            var controller = GerarController(out _);
            var autor = AutorViewModelBogus.GerarAutorViewModel();
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Post, autor);

            var entrada = new InserirAutorViewModel
            {
                Nome = autor.Nome,
                Email = autor.Email,
                Pais = autor.Pais
            };

            _inserirAutorUseCase
                .Setup(x => x.Executar(It.IsAny<InserirAutorViewModel>()))
                .ReturnsAsync(autor);

            var resultado = await controller.Post(entrada);

            ((CreatedResult) resultado).Value
                .Should().BeEquivalentTo(((CreatedResult) esperado).Value);
        }

        [Fact]
        public async Task PATH_DeveExecutar()
        {
            var controller = GerarController(out _);
            var autor = AutorViewModelBogus.GerarAutorViewModel();
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Patch, autor);

            var entrada = new AtualizarAutorViewModel
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Email = autor.Email,
                Pais = autor.Pais
            };

            _atualizarAutorUseCase
                .Setup(x => x.Executar(It.IsAny<Guid>(), It.IsAny<AtualizarAutorViewModel>()))
                .ReturnsAsync(autor);

            var resultado = await controller.Put(autor.Id, entrada);

            ((AcceptedResult) resultado).Value
                .Should().BeEquivalentTo(((AcceptedResult) esperado).Value);
        }

        [Fact]
        public async Task DELETE_DeveExecutar()
        {
            var controller = GerarController(out _);

            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Delete, null);

            _excluirAutorUseCase
                .Setup(x => x.Executar(It.IsAny<Guid>()));

            var resultado = await controller.Delete(Guid.NewGuid());

            resultado.Should().NotBeNull();
            ((NoContentResult) resultado).Should().BeEquivalentTo((NoContentResult) esperado);
            _excluirAutorUseCase
                .Verify(x => x.Executar(It.IsAny<Guid>()), Times.Once);
        }
    }
}