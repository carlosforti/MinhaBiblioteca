using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.UtilTests.Bogus.Editora;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.Mapeamentos
{
    public class ViewModelsParaEntidadesProfileTest
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;

        [Fact]
        public void Mapeamento_DeveMapear_InserirEditoraViewModel_ParaEdtora_ComIdZero()
        {
            var esperado = EditoraBogus.GerarEditora(0); 
            
            var inserirEditoraCommand = new InserirEditoraViewModel()
            {
                Nome = esperado.Nome,
                Email = esperado.Email,
                Pais = esperado.Pais
            };
            
            var resultado = _mapper.Map<Editora>(inserirEditoraCommand);

            resultado.Should().BeEquivalentTo(esperado);
            resultado.Id.Should().Be(0);
        }

        [Fact]
        public void Mapeamento_DeveMapear_AtualizarEditoraViewModel()
        {
            var esperado = EditoraBogus.GerarEditora();
            
            var atualizarEditoraCommand = new AtualizarEditoraViewModel()
            {
                Id = esperado.Id,
                Nome = esperado.Nome,
                Email = esperado.Email,
                Pais = esperado.Pais
            };

            var resultado = _mapper.Map<Editora>(atualizarEditoraCommand);
            
            resultado.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public void Mapeamento_DeveMapear_InserirAutorViewModel_ParaAutor()
        {
            var viewModel = new InserirAutorViewModel
            {
                Nome = "Autor",
                Email = "email@autor.com",
                Pais = "Brasil"
            };
            var esperado = new Autor(0, viewModel.Nome, viewModel.Email, viewModel.Pais);

            var resultado = _mapper.Map<Autor>(viewModel);

            resultado.Should().BeEquivalentTo(esperado);
        }

        [Fact]
        public void Mapeamento_DeveMapear_AtualizarAutorViewModel()
        {
            var viewModel = new AutorViewModel
            {
                Id = 1,
                Nome = "Autor",
                Email = "email@autor.com",
                Pais = "Brasil"
            };

            var esperado = new Autor(viewModel.Id, viewModel.Nome, viewModel.Email, viewModel.Pais);

            var resultado = _mapper.Map<Autor>(esperado);
            
            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}