using AutoMapper;
using FluentAssertions;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Application.Mapeamentos;
using MinhaBiblioteca.Domain.Entities;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Application.Mapeamentos
{
    public class CommandsParaEntidadesProfileTest
    {
        private readonly IMapper _mapper;
        
        public CommandsParaEntidadesProfileTest()
        {
            var mapperConfiguration = new AutoMapper.MapperConfiguration(
                options =>
                {
                    options.AddProfile(new CommandsParaEntidadesProfile());
                });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public void Mapeamento_DeveMapear_InserirEditoraCommand_ParaEdtora_ComIdZero()
        {
            var inserirEditoraCommand = new InserirEditoraCommand()
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
        public void Mapeamento_DeveMapear_AtualizarEditoraCommand()
        {
            var atualizarEditoraCommand = new AtualizarEditoraCommand()
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
    }
}