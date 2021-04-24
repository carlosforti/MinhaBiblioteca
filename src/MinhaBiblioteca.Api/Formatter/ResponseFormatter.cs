using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
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
            var retorno = new Response<object>(null, _notificador);
            return _notificador.StatusCode switch
            {
                HttpStatusCode.NoContent => new NoContentResult(),
                HttpStatusCode.NotFound => GerarObjetoErro(retorno, HttpStatusCode.NotFound),
                HttpStatusCode.InternalServerError => GerarObjetoErro(retorno, HttpStatusCode.InternalServerError),
                _ => new BadRequestObjectResult(retorno)
            };
        }

        private static ObjectResult GerarObjetoErro(Response<object> response, HttpStatusCode httpStatusCode)
        {
            var resultado = new ObjectResult(response)
            {
                StatusCode = (int) httpStatusCode
            };
            return resultado;
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
                    return new OkObjectResult(retorno);
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