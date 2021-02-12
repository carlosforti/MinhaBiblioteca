using AutoMapper;
using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Mapeamentos
{
    public class ViewModelsParaEntidadesProfile: Profile
    {
        public ViewModelsParaEntidadesProfile()
        {
            CreateMap<InserirEditoraViewModel, Editora>()
                .ConstructUsing((viewModel,
                    context) => new Editora(0,
                    viewModel.Nome,
                    viewModel.Email,
                    viewModel.Pais));
            
            CreateMap<AtualizarEditoraViewModel, Editora>();

            CreateMap<InserirAutorViewModel, Autor>()
                .ConstructUsing((viewModel, context) => new Autor(0, viewModel.Nome, viewModel.Email, viewModel.Pais));

            CreateMap<AtualizarAutorViewModel, Autor>();
        }
    }
}