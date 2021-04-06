using AutoMapper;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Mappings
{
    public class ViewsParaEntidadesProfile : Profile
    {
        public ViewsParaEntidadesProfile()
        {
            CreateMap<LivroView, Livro>();
            CreateMap<AutorView, Autor>();
            CreateMap<EditoraView, Editora>();
        }
    }
}