using AutoMapper;
using MinhaBiblioteca.Application.ViewModels.Autor;
using MinhaBiblioteca.Application.ViewModels.Editora;
using MinhaBiblioteca.Domain.Entities;

namespace MinhaBiblioteca.Application.Mapeamentos
{
    public class EntidadesParaViewModelsProfile : Profile
    {
        public EntidadesParaViewModelsProfile()
        {
            CreateMap<Editora, EditoraViewModel>();
            CreateMap<Editora, EditoraResumidaViewModel>();
            CreateMap<Autor, AutorViewModel>();
            CreateMap<Autor, AutorResumidoViewModel>();
        }
    }
}