using AutoMapper;
using MinhaBiblioteca.Application.Cqrs.Commands;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Mapeamentos
{
    public class CommandsParaEntidadesProfile: Profile
    {
        public CommandsParaEntidadesProfile()
        {
            CreateMap<InserirEditoraCommand, Editora>()
                .ConstructUsing((command, context) => new Editora(0, command.Nome, command.Email, command.Pais));
            
            CreateMap<AtualizarEditoraCommand, Editora>();
        }
    }
}