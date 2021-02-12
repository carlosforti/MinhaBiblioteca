using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Mapeamentos;
using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Domain.Entities;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.Mapeamentos
{
    public class ViewModelsParaEntidadesProfileTest
    {
        private readonly IMapper _mapper;
        
        public ViewModelsParaEntidadesProfileTest()
        {
            var mapperConfiguration = new AutoMapper.MapperConfiguration(
                options =>
                {
                    options.AddProfile(new ViewModelsParaEntidadesProfile());
                });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public void Mapeamento_DeveMapear_InserirEditoraViewModel_ParaEdtora_ComIdZero()
        {
            var inserirEditoraCommand = new InserirEditoraViewModel()
            {
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };
            var esperado = new Editora(0, inserirEditoraCommand.Nome, inserirEditoraCommand.Email,
                inserirEditoraCommand.Pais);

            var resultado = _mapper.Map<Editora>(inserirEditoraCommand);

            resultado.Should().BeEquivalentTo(esperado);
            resultado.Id.Should().Be(0);
        }

        [Fact]
        public void Mapeamento_DeveMapear_AtualizarEditoraViewModel()
        {
            var atualizarEditoraCommand = new AtualizarEditoraViewModel()
            {
                Id = 1,
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var esperado = new Editora(atualizarEditoraCommand.Id, atualizarEditoraCommand.Nome,
                atualizarEditoraCommand.Email, atualizarEditoraCommand.Pais);

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