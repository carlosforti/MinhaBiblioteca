using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.Interfaces.Data.Editora;
using MinhaBiblioteca.Application.UseCases.Editora;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Editora
{
    public class AtualizarEditoraUseCaseTest
    {
        private readonly IMapper _mapper = AutoMapperTestHelper.Mapper;
        private readonly Mock<IEditoraRepository> _editoraRepository = new();
        private readonly INotificador _notificador = new Notificador();
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotifica_EmCasoDeErro()
        {
            var viewModel = new AtualizarEditoraViewModel()
            {
                Id = 1,
                Email = "contato@editora.com",
                Nome = "Editora",
                Pais = "Brasil"
            };

            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("Editora", "Erro de banco de dados");

            _editoraRepository
                .Setup(x => x.AtualizarEditora(It.IsAny<Domain.Entities.Editora>()))
                .Callback(() => _notificador.AdicionarErro("Editora", "Erro de banco de dados"));

            var useCase = new AtualizarEdiitoraUseCase(_mapper, _editoraRepository.Object, _notificador);

            var resultado = await useCase.Executar(viewModel.Id, viewModel);

            resultado.Should().BeNull();
            _notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotifica_QuandoIdDiferenteNaRotaEBody()
        {
            var viewModel = new AtualizarEditoraViewModel()
            {
                Id = 1,
                Email = "contato@editora.com",
                Nome = "Editora",
                Pais = "Brasil"
            };
            
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("id", "Id informado não corresponde ao da rota");

            var useCase = new AtualizarEdiitoraUseCase(_mapper, _editoraRepository.Object, _notificador);

            var resultado = await useCase.Executar(viewModel.Id + 1, viewModel);

            resultado.Should().BeNull();
            _notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }
        
        [Fact]
        public async Task Executar_DeveRetornar_QuandoForSucesso()
        {
            var viewModel = new AtualizarEditoraViewModel()
            {
                Id = 1,
                Email = "contato@editora.com",
                Nome = "Editora",
                Pais = "Brasil"
            };

            var editora = new Domain.Entities.Editora(viewModel.Id, viewModel.Nome, viewModel.Email,
                viewModel.Pais);

            var esperado = new EditoraViewModel()
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Email = viewModel.Email,
                Pais = viewModel.Pais
            };
            
            _editoraRepository
                .Setup(x => x.AtualizarEditora(It.IsAny<Domain.Entities.Editora>()))
                .ReturnsAsync(editora);
            
            var useCase = new AtualizarEdiitoraUseCase(_mapper, _editoraRepository.Object, _notificador);

            var resultado = await useCase.Executar(viewModel.Id, viewModel);

            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}