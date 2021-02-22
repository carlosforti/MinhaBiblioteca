using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Livros;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Livros
{
    public class ExcluirLivroUseCaseTest
    {
        [Fact]
        public async Task Executar_DeveChamarMetodoDeRepository()
        {
            var repository = new Mock<ILivroRepository>();
            var useCase = new ExcluirLivroUseCase(repository.Object);

            await useCase.Executar(1);
            repository.Verify(x => x.ExcluirLivro(It.IsAny<int>()), Times.Once);
        }
    }
}