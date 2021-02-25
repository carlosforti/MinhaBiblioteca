using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MinhaBiblioteca.API.Formatter
{
    public interface IResponseFormatter
    {
        IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, object valor);
        IActionResult FormatarResposta(TipoRequisicao tipoRequisicao, IEnumerable<object> valor);
    }
}