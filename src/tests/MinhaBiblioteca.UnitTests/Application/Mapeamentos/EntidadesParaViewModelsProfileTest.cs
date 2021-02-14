using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.UtilTests.Mapeamento;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.Mapeamentos
{
    public class EntidadesParaViewModelsProfileTest
    {
        private readonly IMapper _mapper = AutoMapperHelper.Mapper;

        [Fact]
        public void Mapeamento_DeveMapear_Editora_ParaEditoraViewModel()
        {
            var editora = new Editora(1, "Editora", "editora@editora.com", "Brasil");
            var esperado = new EditoraViewModel()
            {
                Id = editora.Id,
                Nome = editora.Nome,
                Email = editora.Email,
                Pais = editora.Pais
            };

            var resultado = _mapper.Map<EditoraViewModel>(editora);
            
            resultado.Should().BeEquivalentTo(esperado);
        }
        
        [Fact]
        public void Mapeamento_DeveMapear_Editora_ParaEditoraResumidaViewModel()
        {
            var editora = new Editora(1, "Editora", "editora@editora.com", "Brasil");
            var esperado = new EditoraResumidaViewModel()
            {
                Id = editora.Id,
                Nome = editora.Nome
            };

            var resultado = _mapper.Map<EditoraResumidaViewModel>(editora);
            
            resultado.Should().BeEquivalentTo(esperado);
        }
    }
}