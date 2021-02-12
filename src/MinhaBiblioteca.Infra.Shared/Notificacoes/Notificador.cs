using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MinhaBiblioteca.Infra.Shared.Notificacoes
{
    public interface INotificador
    {
        IEnumerable<Notificacao> Erros { get; }
        IEnumerable<Notificacao> Avisos { get; }
        bool TemErros { get; }
        HttpStatusCode StatusCode { get; }
        void AdicionarErro(string propriedade, string mensagem);
        void AdicionarAviso(string propriedade, string mensagem);
        void AdicionarErro(string propriedade, string mensagem, HttpStatusCode statusCode);
    }

    public class Notificador : INotificador
    {
        public HttpStatusCode StatusCode { get; private set; }

        private readonly List<Notificacao> _notificacoes = new List<Notificacao>();

        public IEnumerable<Notificacao> Erros =>
            _notificacoes.Where(x => x.TipoNotificacao == TipoNotificacao.Erro);

        public IEnumerable<Notificacao> Avisos =>
            _notificacoes.Where(x => x.TipoNotificacao == TipoNotificacao.Aviso);

        public bool TemErros => _notificacoes.Any(x => x.TipoNotificacao == TipoNotificacao.Erro);

        public void AdicionarErro(string propriedade, string mensagem, HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            _notificacoes.Add(new Notificacao(TipoNotificacao.Erro, propriedade, mensagem));
        }

        public void AdicionarErro(string propriedade, string mensagem)
        {
            _notificacoes.Add(new Notificacao(TipoNotificacao.Erro, propriedade, mensagem));
        }

        public void AdicionarAviso(string propriedade, string mensagem) =>
            _notificacoes.Add(new Notificacao(TipoNotificacao.Aviso, propriedade, mensagem));
    }
}