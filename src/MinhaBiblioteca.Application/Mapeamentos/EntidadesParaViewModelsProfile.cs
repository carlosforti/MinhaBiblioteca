using AutoMapper;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Mapeamentos
{
    public class EntidadesParaViewModelsProfile : Profile
    {
        public EntidadesParaViewModelsProfile()
        {
            CreateMap<Editora, EditoraViewModel>();
            CreateMap<Editora, EditoraResumidaViewModel>();
        }
    }
}