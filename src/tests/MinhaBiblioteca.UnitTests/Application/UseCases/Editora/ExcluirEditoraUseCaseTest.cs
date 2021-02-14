using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Editoras;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Editora
{
    public class ExcluirEditoraUseCaseTest
    {
        private readonly Mock<IEditoraRepository> _editoraRepository = new ();

        [Fact]
        public async Task Executar_DeveExcluirEditora()
        {
            _editoraRepository.Setup(x => x.ExcluirEditora(It.IsAny<int>()));
            var useCase = new ExcluirEditoraUseCase(_editoraRepository.Object);
            await useCase.Executar(1);
            _editoraRepository.Verify(x=>x.ExcluirEditora(1), Times.Once);
        }
    }
}