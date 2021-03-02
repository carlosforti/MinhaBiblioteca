using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Infra.Shared.Notificacoes;

namespace MinhaBiblioteca.API.Formatter
{
    public class ResponseFormatter : IResponseFormatter
    {
        private readonly INotificador _notificador;

        public ResponseFormatter(INotificador notificador)
        {
            _notificador = notificador;
        }

        private IActionResult FormatarErros()
        {
            return _notificador.StatusCode switch
            {
                HttpStatusCode.NoContent => new NoContentResult(),
                HttpStatusCode.NotFound => new NotFoundResult(),
                HttpStatusCode.InternalServerError => new StatusCodeResult((int)HttpStatusCode.InternalServerError),
                _ => new BadRequestObjectResult(_notificador.Erros)
            };
        }

        public IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, object valor)
        {
            if (_notificador.ExistemErros)
            {
                return FormatarErros();
            }

            var retorno = new Response<object>(valor, _notificador);

            switch (tipoRequisicao)
            {
                case TipoRequisicao.Post:
                    return new CreatedResult("", retorno);
                case TipoRequisicao.Put:
                case TipoRequisicao.Patch:
                    return new AcceptedResult("", retorno);
                case TipoRequisicao.Delete:
                    return new NoContentResult();
                default:
                    return new OkObjectResult(valor);
            }
        }

        public IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, IEnumerable<object> valor)
        {
            if (_notificador.ExistemErros)
                return FormatarErros();

            if (valor == null || !valor.Any())
                return new NoContentResult();

            var retorno = new Response<object>(valor, _notificador);
            return new OkObjectResult(retorno);
        }
    }
}