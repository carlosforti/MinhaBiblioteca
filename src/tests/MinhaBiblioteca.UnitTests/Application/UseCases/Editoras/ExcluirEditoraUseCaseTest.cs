using System;
using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Editoras
{
    public class ExcluirEditoraUseCaseTest
    {
        private readonly Mock<IEditoraRepository> _editoraRepository = new ();

        [Fact]
        public async Task Executar_DeveExcluirEditora()
        {
            var id = Guid.NewGuid();
            _editoraRepository.Setup(x => x.ExcluirEditora(It.IsAny<Guid>()));
            var useCase = new ExcluirEditoraUseCase(_editoraRepository.Object);
            await useCase.Executar(id);
            _editoraRepository.Verify(x=>x.ExcluirEditora(id), Times.Once);
        }
    }
}