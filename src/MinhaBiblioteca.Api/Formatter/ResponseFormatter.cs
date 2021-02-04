using System.Net;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Microsoft.AspNetCore.Mvc;

namespace MinhaBiblioteca.Api.Formatter
{
    public interface IResponseFormatter
    {
        IActionResult FormatarResposta(object valor);
    }

    public class ResponseFormatter : IResponseFormatter
    {
        private readonly INotificador _notificador;
        public ResponseFormatter(INotificador notificador)
        {
            _notificador = notificador;
        }

        public IActionResult FormatarResposta(object valor)
        {
            if (_notificador.TemErros)
            {
                return FormatarErros();
            }

            return new OkObjectResult(valor);
        }

        private IActionResult FormatarErros()
        {
            return _notificador.StatusCode switch
            {
                HttpStatusCode.NoContent => new NoContentResult(),
                HttpStatusCode.NotFound => new NotFoundResult(),
                HttpStatusCode.InternalServerError => new ObjectResult(null),
                _ => new BadRequestObjectResult(_notificador.Erros)
            };
        }
    }
}