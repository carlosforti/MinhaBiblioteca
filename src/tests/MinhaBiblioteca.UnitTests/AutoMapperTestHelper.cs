using AutoMapper;
using MinhaBiblioteca.Application.Mapeamentos;

namespace MinhaBiblioteca.UnitTests
{
    public static class AutoMapperTestHelper
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var configuration = new MapperConfiguration(options =>
                    {
                        options.AddProfile<ViewModelsParaEntidadesProfile>();
                        options.AddProfile<EntidadesParaViewModelsProfile>();
                    });
                    _mapper = configuration.CreateMapper();
                };

                return _mapper;
            }
        }
    }
}