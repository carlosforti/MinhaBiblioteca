using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores;
using MinhaBiblioteca.Application.ViewModels.Autores;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using MinhaBiblioteca.UtilTests.Bogus.Autores;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases.Autores
{
    public class AtualizarAutorUseCaseTest
    {
        private readonly Mock<IAutorRepository> _autorRepository = new();
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;

        [Fact]
        public async Task Executar_DeveRetornarErro_QuandoIdDiferenteDoIdRota()
        {
            var newId = Guid.NewGuid();
            var viewModel = new AtualizarAutorViewModel
            {
                Id = newId,
                Nome = "Autor",
                Email = "email@autor.com",
                Pais = "Brasil"
            };

            var useCase = GerarAtualizarAutorUseCase(out var notificador);
            var notificadorEsperado = new Notificador();
            notificadorEsperado.AdicionarErro("id", "Id informado não corresponde ao da rota");

            var resultado = await useCase.Executar(Guid.NewGuid(), viewModel);

            resultado.Should().BeNull();
            notificador.Erros.Should().BeEquivalentTo(notificadorEsperado.Erros);
        }

        [Fact]
        public async Task Executar_DeveRetornar_QuandoForSucesso()
        {
            var esperado = AutorBogus.GerarAutor();

            var viewModel = new AtualizarAutorViewModel
            {
                Id = esperado.Id,
                Nome = esperado.Nome,
                Email = esperado.Email,
                Pais = esperado.Pais
            };

            _autorRepository
                .Setup(x => x.AtualizarAutor(It.IsAny<Domain.Entities.Autor>()))
                .ReturnsAsync(esperado);

            var useCase = GerarAtualizarAutorUseCase(out var notificador);
            var resultado = await useCase.Executar(viewModel.Id, viewModel);

            resultado.Should().BeEquivalentTo(esperado);
            _autorRepository
                .Verify(x => x.AtualizarAutor(It.IsAny<Domain.Entities.Autor>()), Times.Once);
        }

        private AtualizarAutorUseCase GerarAtualizarAutorUseCase(out INotificador notificador)
        {
            notificador = new Notificador();
            return new AtualizarAutorUseCase(_mapper, _autorRepository.Object, notificador);
        }
    }
}