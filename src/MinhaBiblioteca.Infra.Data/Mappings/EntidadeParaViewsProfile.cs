using AutoMapper;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Data.Views;

namespace MinhaBiblioteca.Infra.Data.Mappings
{
    public class EntidadeParaViewsProfile : Profile
    {
        public EntidadeParaViewsProfile()
        {
            CreateMap<Livro, LivroView>()
                .ForMember(src => src.Autor, opt => opt.Ignore())
                .ForMember(src => src.Editora, opt => opt.Ignore());

            CreateMap<Autor, AutorView>();
            CreateMap<Editora, EditoraView>();
        }
    }
}
