using AutoMapper;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Mappings
{
    public class EntidadeParaViewsProfile : Profile
    {
        public EntidadeParaViewsProfile()
        {
            CreateMap<Livro, LivroView>();
            CreateMap<Autor, AutorView>();
            CreateMap<Editora, EditoraView>();
        }
    }
}
