using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases
{
    public class AtualizarEditoraUseCaseTest
    {
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<IEditoraCommand> _editoraCommand = new Mock<IEditoraCommand>();
        private readonly INotificador _notificador = new Notificador();
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotifica_EmCasoDeErro()
        {
            var editoraCommand = new AtualizarEditoraCommand()
            {
                Id = 1,
                Email = "contato@editora.com",
                Nome = "Editora",
                Pais = "Brasil"
            };

            var editora = new Editora(editoraCommand.Id, editoraCommand.Nome, editoraCommand.Email,
                editoraCommand.Pais);

            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("Editora", "Erro de banco de dados");
            
            _mapper
                .Setup(x => x.Map<Editora>(It.IsAny<AtualizarEditoraCommand>()))
                .Returns(editora);

            _editoraCommand
                .Setup(x => x.AtualizarEditora(It.IsAny<Editora>()))
                .Callback(() => _notificador.AdicionarErro("Editora", "Erro de banco de dados"));

            var useCase = new AtualizarEdiitoraUseCase(_mapper.Object, _editoraCommand.Object, _notificador);

            var resultado = await useCase.Executar(editora.Id, editoraCommand);

            resultado.Should().BeNull();
            _notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_ENotifica_QuandoIdDiferenteNaRotaEBody()
        {
            var editoraCommand = new AtualizarEditoraCommand()
            {
                Id = 1,
                Email = "contato@editora.com",
                Nome = "Editora",
                Pais = "Brasil"
            };
            var editora = new Editora(editoraCommand.Id, editoraCommand.Nome, editoraCommand.Email,
                editoraCommand.Pais);

            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("id", "Id informado não corresponde ao da rota");
            
            _mapper
                .Setup(x => x.Map<Editora>(It.IsAny<AtualizarEditoraCommand>()))
                .Returns(editora);
            
            var useCase = new AtualizarEdiitoraUseCase(_mapper.Object, _editoraCommand.Object, _notificador);

            var resultado = await useCase.Executar(editora.Id + 1, editoraCommand);

            resultado.Should().BeNull();
            _notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }
        
        [Fact]
        public async Task Executar_DeveRetornar_QuandoForSucesso()
        {
            var editoraCommand = new AtualizarEditoraCommand()
            {
                Id = 1,
                Email = "contato@editora.com",
                Nome = "Editora",
                Pais = "Brasil"
            };

            var editora = new Editora(editoraCommand.Id, editoraCommand.Nome, editoraCommand.Email,
                editoraCommand.Pais);

            var esperado = new EditoraViewModel()
            {
                Id = editora.Id,
                Nome = editora.Nome,
                Email = editora.Email,
                Pais = editora.Pais
            };

            _mapper
                .Setup(x => x.Map<Editora>(It.IsAny<AtualizarEditoraCommand>()))
                .Returns(editora);

            _mapper
                .Setup(x => x.Map<EditoraViewModel>(It.IsAny<Editora>()))
                .Returns(esperado);

            _editoraCommand
                .Setup(x => x.AtualizarEditora(It.IsAny<Editora>()))
                .ReturnsAsync(editora);
            
            var useCase = new AtualizarEdiitoraUseCase(_mapper.Object, _editoraCommand.Object, _notificador);

            var resultado = await useCase.Executar(editora.Id, editoraCommand);

            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}