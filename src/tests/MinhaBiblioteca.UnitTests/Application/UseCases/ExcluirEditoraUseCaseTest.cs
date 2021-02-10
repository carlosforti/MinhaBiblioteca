using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases
{
    public class ExcluirEditoraUseCaseTest
    {
        private readonly Mock<IEditoraCommand> _editoraCommand = new Mock<IEditoraCommand>();

        [Fact]
        public async Task Executar_DeveExcluirEditora()
        {
            _editoraCommand.Setup(x => x.ExcluirEditora(It.IsAny<int>()));
            var useCase = new ExcluirEditoraUseCase(_editoraCommand.Object);
            await useCase.Executar(1);
            _editoraCommand.Verify(x=>x.ExcluirEditora(1), Times.Once);
        }
    }
}