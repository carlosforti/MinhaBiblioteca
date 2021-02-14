namespace MinhaBiblioteca.Infra.Shared.Notificacoes
{
    public class Notificacao
    {
        public Notificacao(TipoNotificacao tipoNotificacao, string propriedade, string mensagem)
        {
            TipoNotificacao = tipoNotificacao;
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public TipoNotificacao TipoNotificacao { get; set; }
        public string Propriedade { get; protected set; }
        public string Mensagem { get; protected set; }
    }
}