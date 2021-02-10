using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Domain.Entities;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases
{
    public class InserirEditoraUseCaseTest
    {
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<IEditoraCommand> _editoraCommand = new Mock<IEditoraCommand>();

        [Fact]
        public async Task Executar_DeveInserirEditora()
        {
            var inserirEditoraCommand = new InserirEditoraCommand()
            {
                Nome = "editora",
                Email = "contato@editora.com",
                Pais = "Brasil"
            };

            var esperado = new EditoraViewModel
            {
                Id = 1,
                Nome = inserirEditoraCommand.Nome,
                Email = inserirEditoraCommand.Email,
                Pais = inserirEditoraCommand.Pais
            };

            var editoraMap = new Editora(0, inserirEditoraCommand.Nome, inserirEditoraCommand.Email,
                inserirEditoraCommand.Pais);

            var editora = new Editora(1, inserirEditoraCommand.Nome, inserirEditoraCommand.Email, inserirEditoraCommand.Pais);

            _mapper
                .Setup(x => x.Map<Editora>(It.IsAny<InserirEditoraCommand>()))
                .Returns(editoraMap);

            _mapper
                .Setup(x => x.Map<EditoraViewModel>(It.IsAny<Editora>()))
                .Returns(esperado);
            
            _editoraCommand.Setup(x => x.AdicionarEditora(It.IsAny<Editora>()))
                .ReturnsAsync(editora);

            var useCase = new InserirEditoraUseCase(_mapper.Object, _editoraCommand.Object);

            var resultado = await useCase.Executar(inserirEditoraCommand);
            
            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}