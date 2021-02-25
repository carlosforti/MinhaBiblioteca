using AutoMapper;
using MinhaBiblioteca.Application.Mapeamentos;

namespace MinhaBiblioteca.UtilTests.Mapeamento
{
    public static class AutoMapperHelper
    {
        public static IMapper Mapper { get; }

        static AutoMapperHelper()
        {
            var mapperConfiguration = new MapperConfiguration(
                options =>
                {
                    options.AddProfile(new EntidadesParaViewModelsProfile());
                    options.AddProfile(new ViewModelsParaEntidadesProfile());
                });
            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}