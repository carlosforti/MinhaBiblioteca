using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Editoras;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Editoras
{
    public class AtualizarEditoraUseCaseTest
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;
        private readonly Mock<IEditoraRepository> _editoraRepository = new();
        private readonly INotificador _notificador = new Notificador();
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotifica_EmCasoDeErro()
        {
            var viewModel = new AtualizarEditoraViewModel
            {
                Id = Guid.NewGuid(),
                Email = "contato@editora.com",
                Nome = "Editora",
                Pais = "Brasil"
            };

            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("Editora", "Erro de banco de dados");

            _editoraRepository
                .Setup(x => x.AtualizarEditora(It.IsAny<Domain.Entities.Editora>()))
                .Callback(() => _notificador.AdicionarErro("Editora", "Erro de banco de dados"));

            var useCase = new AtualizarEditoraUseCase(_mapper, _editoraRepository.Object, _notificador);

            var resultado = await useCase.Executar(viewModel.Id, viewModel);

            resultado.Should().BeNull();
            _notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotificar_QuandoIdDiferenteNaRotaEBody()
        {
            var viewModel = new AtualizarEditoraViewModel
            {
                Id = Guid.NewGuid(),
                Email = "contato@editora.com",
                Nome = "Editora",
                Pais = "Brasil"
            };
            
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("id", "Id informado não corresponde ao da rota");

            var useCase = new AtualizarEditoraUseCase(_mapper, _editoraRepository.Object, _notificador);

            var resultado = await useCase.Executar(Guid.NewGuid(), viewModel);

            resultado.Should().BeNull();
            _notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }
        
        [Fact]
        public async Task Executar_DeveRetornar_QuandoForSucesso()
        {
            var esperado = EditoraViewModelBogus.GerarEditoraViewModel();
            
            var viewModel = new AtualizarEditoraViewModel
            {
                Id = esperado.Id,
                Nome = esperado.Nome,
                Email = esperado.Email,
                Pais = esperado.Pais
            };

            var editora = new Domain.Entities.Editora(viewModel.Id, viewModel.Nome, viewModel.Email,
                viewModel.Pais);

            _editoraRepository
                .Setup(x => x.AtualizarEditora(It.IsAny<Domain.Entities.Editora>()))
                .ReturnsAsync(editora);
            
            var useCase = new AtualizarEditoraUseCase(_mapper, _editoraRepository.Object, _notificador);

            var resultado = await useCase.Executar(viewModel.Id, viewModel);

            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}