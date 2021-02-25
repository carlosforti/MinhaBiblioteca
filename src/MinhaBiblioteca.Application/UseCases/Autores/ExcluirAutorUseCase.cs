using System.Threading.Tasks;
using MinhaBiblioteca.Application.Interfaces.Data;
using MinhaBiblioteca.Application.UseCases.Autores.Interfaces;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.Application.UseCases.Autores
{
    public class ExcluirAutorUseCase : IExcluirAutorUseCase
    {
        private readonly INotificador _notificador;
        private readonly IAutorRepository _autorRepository;
        
        public ExcluirAutorUseCase(INotificador notificador, IAutorRepository autorRepository)
        {
            _notificador = notificador;
            _autorRepository = autorRepository;
        }

        public async Task Executar(int id)
        {
            await _autorRepository.ExcluirAutor(id);
        }
    }
}