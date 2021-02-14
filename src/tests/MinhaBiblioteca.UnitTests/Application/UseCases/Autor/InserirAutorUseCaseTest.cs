using System.Threading.Tasks;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data.Autores;
using MinhaBiblioteca.Application.UseCases.Autores;
using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.UtilTests.Bogus;
using MinhaBiblioteca.UtilTests.Bogus.Autor;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Autor
{
    public class InserirAutorUseCaseTest
    {
        [Fact]
        public async Task DeveInserirAutor_ERetornarIdDiferenteZero()
        {
            var mapper = AutoMapperHelper.Mapper;
            var command = new Mock<IAutorCommand>();

            var autorInserido = AutorBogus.GerarAutor();

            var viewModel = new InserirAutorViewModel
            {
                Nome = autorInserido.Nome,
                Email = autorInserido.Email,
                Pais = autorInserido.Pais
            };
            
            var esperado = new AutorViewModel
            {
                Id = autorInserido.Id,
                Nome = autorInserido.Nome,
                Email = autorInserido.Email,
                Pais = autorInserido.Pais
            };

            command
                .Setup(x => x.InserirAutor(It.IsAny<Domain.Entities.Autor>()))
                .ReturnsAsync(autorInserido);

            var useCase = new InserirAutorUseCase(mapper, command.Object);

            var resultado = await useCase.Executar(viewModel);

            command.Verify(x => x.InserirAutor(It.IsAny<Domain.Entities.Autor>()), Times.Once);
            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}