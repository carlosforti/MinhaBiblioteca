using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ListarEditorasUseCaseTest
    {
        private readonly Mock<IMapper> _mapper = new ();
        private readonly Mock<IEditoraRepository> _editoraRepository = new ();

        private static List<EditoraResumidaViewModel> GerarListaEditorasResumidas(IEnumerable<Domain.Entities.Editora> editoras)
        {
            return editoras.Select(e => new EditoraResumidaViewModel
            {
                Id = e.Id,
                Nome = e.Nome
            }).ToList();
        }
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_QuandoNaoEncontrar()
        {
            _mapper
                .Setup(x => x.Map<IEnumerable<EditoraResumidaViewModel>>(It.IsAny<IEnumerable<Domain.Entities.Editora>>()))
                .Returns(null as List<EditoraResumidaViewModel>);

            _editoraRepository
                .Setup(x => x.ListarEditoras())
                .ReturnsAsync(null as List<Domain.Entities.Editora>);

            var useCase = new ListarEditorasUseCase(_mapper.Object, _editoraRepository.Object);

            var resultado = await useCase.Executar();

            resultado.Should().BeNull();
        }

        [Fact]
        public async Task Executar_DeveRetornarListaDeEditoras()
        {
            var editoras = new List<Domain.Entities.Editora>
            {
                new(Guid.NewGuid(), "Editora", "contato@editora.com", "Brasil"),
                new(Guid.NewGuid(), "Publiher", "publisher@publisher.com", "England")
            };

            var esperado = GerarListaEditorasResumidas(editoras);

            _mapper
                .Setup(x => x.Map<IEnumerable<EditoraResumidaViewModel>>(It.IsAny<IEnumerable<Domain.Entities.Editora>>()))
                .Returns(esperado);
            
            _editoraRepository
                .Setup(x => x.ListarEditoras())
                .ReturnsAsync(editoras);

            var useCase = new ListarEditorasUseCase(_mapper.Object, _editoraRepository.Object);

            var resultado = await useCase.Executar();

            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}