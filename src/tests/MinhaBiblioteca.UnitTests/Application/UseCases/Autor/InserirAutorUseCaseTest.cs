using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data.Autor;
using MinhaBiblioteca.Application.UseCases.Autor;
using MinhaBiblioteca.Application.ViewModels.Autor;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Autor
{
    public class InserirAutorUseCaseTest
    {
        [Fact]
        public async Task DeveInserirAutor_ERetornarIdDiferenteZero()
        {
            var mapper = AutoMapperTestHelper.Mapper;
            var command = new Mock<IAutorCommand>();

            var viewModel = new InserirAutorViewModel
            {
                Nome = "Autor",
                Email = "autor@autor.com",
                Pais = "Brasil"
            };

            var autorInserido = new Domain.Entities.Autor(1, viewModel.Nome, viewModel.Email, viewModel.Pais);

            var esperado = new AutorViewModel
            {
                Id = 1,
                Nome = viewModel.Nome,
                Email = viewModel.Email,
                Pais = viewModel.Pais
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