using System.Net;
using FluentAssertions;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Infra.Shared.Notificacoes
{
    public class NotificadorTest
    {
        [Fact]
        public void AdicionarErro_DeveAdicionar()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem");

            notificador.TemErros.Should().BeTrue();
            notificador.Erros
                .Should()
                .ContainEquivalentOf(new Notificacao(TipoNotificacao.Erro, "erro", "mensagem"));
        }

        [Fact]
        public void AdicionarAviso_DeveAdicionar()
        {
            var notificador = new Notificador();
            notificador.AdicionarAviso("aviso", "mensagem");

            notificador.TemErros.Should().BeFalse();
            notificador.Avisos
                .Should()
                .ContainEquivalentOf(new Notificacao(TipoNotificacao.Aviso, "aviso", "mensagem"));
        }

        [Fact]
        public void AdicionarErro_ComHttpStatusCode()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NotFound);

            notificador.TemErros.Should().BeTrue();
            notificador.Erros
                .Should()
                .ContainEquivalentOf(new Notificacao(TipoNotificacao.Erro, "erro", "mensagem"));
            notificador.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
    }
}