using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Domain.Entities;
using Moq;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.UseCases
{
    public class ListarEditorasUseCaseTest
    {
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<IEditoraQuery> _editoraQuery = new Mock<IEditoraQuery>();

        private List<EditoraResumidaViewModel> GerarListaEditorasResumidas(IEnumerable<Editora> editoras)
        {
            return editoras.Select(e => new EditoraResumidaViewModel()
            {
                Id = e.Id,
                Nome = e.Nome
            }).ToList();
        }
        
        [Fact]
        public async Task Executar_DeveRetornarNulo_QuandoNaoEncontrar()
        {
            _mapper
                .Setup(x => x.Map<IEnumerable<EditoraResumidaViewModel>>(It.IsAny<IEnumerable<Editora>>()))
                .Returns(null as List<EditoraResumidaViewModel>);

            _editoraQuery
                .Setup(x => x.ListarEditoras())
                .ReturnsAsync(null as List<Editora>);

            var useCase = new ListarEditorasUseCase(_mapper.Object, _editoraQuery.Object);

            var resultado = await useCase.Executar();

            resultado.Should().BeNull();
        }

        [Fact]
        public async Task Executar_DeveRetornarListaDeEditoras()
        {
            var editoras = new List<Editora>
            {
                new Editora(1, "Editora", "contato@editora.com", "Brasil"),
                new Editora(2, "Publiher", "publisher@publisher.com", "England")
            };

            var esperado = GerarListaEditorasResumidas(editoras);

            _mapper
                .Setup(x => x.Map<IEnumerable<EditoraResumidaViewModel>>(It.IsAny<IEnumerable<Editora>>()))
                .Returns(esperado);
            
            _editoraQuery
                .Setup(x => x.ListarEditoras())
                .ReturnsAsync(editoras);

            var useCase = new ListarEditorasUseCase(_mapper.Object, _editoraQuery.Object);

            var resultado = await useCase.Executar();

            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}