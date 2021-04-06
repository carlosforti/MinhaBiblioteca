using AutoMapper;
using MinhaBiblioteca.Infra.Data.Context;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Infra.Data.Repositories
{
    public class RepositoryBase
    {
        public RepositoryBase(BibliotecaContext context, INotificador notifier, IMapper mapper)
        {
            Context = context;
            Notifier = notifier;
            Mapper = mapper;
        }

        protected BibliotecaContext Context;
        protected INotificador Notifier;
        protected IMapper Mapper;
    }
}