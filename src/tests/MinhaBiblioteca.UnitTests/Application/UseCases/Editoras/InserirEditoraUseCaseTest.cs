using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras;
using MinhaBiblioteca.Application.ViewModels.Editoras;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Editoras
{
    public class InserirEditoraUseCaseTest
    {
        private readonly Mock<IMapper> _mapper = new();
        private readonly Mock<IEditoraRepository> _editoraRepository = new();

        [Fact]
        public async Task Executar_DeveInserirEditora()
        {
            var inserirEditoraCommand = new InserirEditoraViewModel
            {
                Nome = "editora",
                Email = "contato@editora.com",
                Pais = "Brasil"
            };

            var esperado = new EditoraViewModel
            {
                Id = Guid.NewGuid(),
                Nome = inserirEditoraCommand.Nome,
                Email = inserirEditoraCommand.Email,
                Pais = inserirEditoraCommand.Pais
            };

            var editoraMap = new Domain.Entities.Editora(Guid.Empty, inserirEditoraCommand.Nome, inserirEditoraCommand.Email,
                inserirEditoraCommand.Pais);

            var editora = new Domain.Entities.Editora(esperado.Id, inserirEditoraCommand.Nome, inserirEditoraCommand.Email, inserirEditoraCommand.Pais);

            _mapper
                .Setup(x => x.Map<Domain.Entities.Editora>(It.IsAny<InserirEditoraViewModel>()))
                .Returns(editoraMap);

            _mapper
                .Setup(x => x.Map<EditoraViewModel>(It.IsAny<Domain.Entities.Editora>()))
                .Returns(esperado);
            
            _editoraRepository.Setup(x => x.AdicionarEditora(It.IsAny<Domain.Entities.Editora>()))
                .ReturnsAsync(editora);

            var useCase = new InserirEditoraUseCase(_mapper.Object, _editoraRepository.Object);

            var resultado = await useCase.Executar(inserirEditoraCommand);
            
            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}