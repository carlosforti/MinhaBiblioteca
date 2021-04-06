using AutoMapper;
using MinhaBiblioteca.Domain.Entities;
using MinhaBiblioteca.Infra.Data.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaBiblioteca.Infra.Data.Mappings
{
    public class EntidadeParaViews : Profile
    {
        public EntidadeParaViews()
        {
            CreateMap<Livro, LivroView>()
                .ForMember(dest => dest.AutorId, opt => opt.MapFrom(src => src.Autor.Id))
                .ForMember(dest => dest.EditoraId, opt => opt.MapFrom(src => src.Editora.Id))
                .ReverseMap();

            CreateMap<Autor, AutorView>()
                .ReverseMap();

            CreateMap<Editora, EditoraView>()
                .ReverseMap();
        }
    }
}
