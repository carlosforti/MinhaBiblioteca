using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.API.Controllers;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.UseCases.Editoras.Interfaces;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Editoras;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Api.Controller
{
    public class EditorasControllerTest
    {
        private readonly Notificador _notificador = new();
        private readonly Mock<IInserirEditoraUseCase> _inserirEditoraUseCase;
        private readonly Mock<IBuscarEditoraPorIdUseCase> _buscarEditoraPorIdUseCase;
        private readonly Mock<IListarEditorasUseCase> _listarEditorasUseCase;
        private readonly IResponseFormatter _responseFormatter;
        private readonly Mock<IAtualizarEditoraUseCase> _atualizarEditorUseCase;
        private readonly Mock<IExcluirEditoraUseCase> _excluirEdtoraUsecase;
        private readonly EditorasController _controller;

        public EditorasControllerTest()
        {
            _inserirEditoraUseCase = new Mock<IInserirEditoraUseCase>();
            _buscarEditoraPorIdUseCase = new Mock<IBuscarEditoraPorIdUseCase>();
            _listarEditorasUseCase = new Mock<IListarEditorasUseCase>();
            _atualizarEditorUseCase = new Mock<IAtualizarEditoraUseCase>();
            _excluirEdtoraUsecase = new Mock<IExcluirEditoraUseCase>();

            _responseFormatter = new ResponseFormatter(_notificador);

            _controller = new EditorasController(_inserirEditoraUseCase.Object,
                _buscarEditoraPorIdUseCase.Object,
                _responseFormatter,
                _listarEditorasUseCase.Object,
                _atualizarEditorUseCase.Object,
                _excluirEdtoraUsecase.Object);
        }

        [Fact]
        public async Task GET_DeveRetornarItemUnico()
        {
            var editoraViewModel = EditoraViewModelBogus.GerarEditoraViewModel(1);
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Get, editoraViewModel) as OkObjectResult;

            _buscarEditoraPorIdUseCase
                .Setup(x => x.Executar(It.IsAny<int>()))
                .ReturnsAsync(editoraViewModel);

            var resultado = (await _controller.GetById(1)) as OkObjectResult;

            (resultado.Value as EditoraViewModel).Should()
                .BeEquivalentTo((esperado.Value as EditoraViewModel));
            _buscarEditoraPorIdUseCase.Verify(x => x.Executar(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GET_DeveRetornarLista()
        {
            var editorasViewModel = EditoraResumidaViewModelBogus
                .GerarEditorasResumidasViewModel(3)
                .ToList();

            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Get, editorasViewModel) as OkObjectResult;

            _listarEditorasUseCase
                .Setup(x => x.Executar())
                .ReturnsAsync(editorasViewModel);

            var resultado = await _controller.Get() as OkObjectResult;
            
            (resultado.Value as Response<IEnumerable<EditoraResumidaViewModel>>)
                .Should().BeEquivalentTo(esperado.Value as Response<IEnumerable<EditoraResumidaViewModel>>);
            _listarEditorasUseCase.Verify(x=>x.Executar(), Times.Once);
        }

        [Fact]
        public async Task POST_DeveExecutar()
        {
            var editora = EditoraViewModelBogus.GerarEditoraViewModel();
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Post, editora) as CreatedAtRouteResult;

            var entrada = new InserirEditoraViewModel
            {
                Nome = editora.Nome,
                Email = editora.Email,
                Pais = editora.Pais
            };
            
            _inserirEditoraUseCase
                .Setup(x => x.Executar(It.IsAny<InserirEditoraViewModel>()))
                .ReturnsAsync(editora);

            var resultado = (await _controller.Post(entrada)) as CreatedAtRouteResult;
            
            (resultado.Value as Response<EditoraViewModel>)
                .Should().BeEquivalentTo(esperado.Value as EditoraViewModel);
            _inserirEditoraUseCase
                .Verify(x => x.Executar(It.IsAny<InserirEditoraViewModel>()), 
                    Times.Once);
        }

        [Fact]
        public async Task PATH_DeveExecutar()
        {
            var editora = EditoraViewModelBogus.GerarEditoraViewModel();
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Patch, editora);

            var entrada = new AtualizarEditoraViewModel
            {
                Id = editora.Id,
                Nome = editora.Nome,
                Email = editora.Email,
                Pais = editora.Pais
            };

            _atualizarEditorUseCase
                .Setup(x => x.Executar(It.IsAny<int>(), 
                    It.IsAny<AtualizarEditoraViewModel>()))
                .ReturnsAsync(editora);

            var resultado =await _controller.Put(editora.Id, entrada);

            ((AcceptedAtRouteResult) resultado).Value
                .Should().BeEquivalentTo(((AcceptedAtRouteResult) esperado).Value);
            _atualizarEditorUseCase
                .Verify(x=>x.Executar(It.IsAny<int>(), 
                    It.IsAny<AtualizarEditoraViewModel>()), Times.Once);
        }
        
        [Fact]
        public async Task DELETE_DeveExecutar()
        {
            var esperado = _responseFormatter.FormatarResposta(TipoRequisicao.Delete, null);
            
            _excluirEdtoraUsecase
                .Setup(x => x.Executar(It.IsAny<int>()));

            var resultado = await _controller.Delete(1);

            resultado.Should().NotBeNull();
            ((NoContentResult)resultado).Should().BeEquivalentTo((NoContentResult)esperado);
            _excluirEdtoraUsecase
                .Verify(x => x.Executar(It.IsAny<int>()), Times.Once);
        }
    }
}