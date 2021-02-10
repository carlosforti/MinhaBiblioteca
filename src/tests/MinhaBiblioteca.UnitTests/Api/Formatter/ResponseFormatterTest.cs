using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MinhaBiblioteca.Api.Formatter;
using MinhaBiblioteca.Application.ViewModels;
using MinhaBiblioteca.Infra.Shared.Notificacoes;
using Xunit;

namespace MinhaBiblioteca.UnitTests.Api.Formatter
{
    public class ResponseFormatterTest
    {
        [Fact]
        public void FormatarResposta_ComErroSemStatusCode_ObjetoUnico()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem");
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = 1,
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<BadRequestObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.BadRequest);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeInternalServerError_ObjetoUnico()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.InternalServerError);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = 1,
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<StatusCodeResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeNoContent_ObjetoUnico()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NoContent);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = 1,
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NoContent);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeNotFound_ObjetoUnico()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NotFound);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = 1,
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NotFound);
        }

        [Fact]
        public void FormatarResposta_ComErroSemStatusCode_Lista()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem");
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new List<EditoraViewModel>
            {
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<BadRequestObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.BadRequest);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeInternalServerError_Lista()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.InternalServerError);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new List<EditoraViewModel>
            {
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<StatusCodeResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeNoContent_Lista()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NoContent);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new List<EditoraViewModel>
            {
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NoContent);
        }

        [Fact]
        public void FormatarResposta_ComErroComStatusCodeNotFound_Lista()
        {
            var notificador = new Notificador();
            notificador.AdicionarErro("erro", "mensagem", HttpStatusCode.NotFound);
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new List<EditoraViewModel>
            {
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);

            resultado.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.NotFound);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_GET()
        {
            var notificador = new Notificador();
            var responseFormatter = new ResponseFormatter(notificador);
            var editora = new EditoraViewModel
            {
                Id = 1,
                Nome = "Editora",
                Email = "editora@editora.com",
                Pais = "Brasil"
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editora);
            resultado.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(editora);

            resultado.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.OK);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_GET_Lista()
        {
            var notificador = new Notificador();
            var responseFormatter = new ResponseFormatter(notificador);
            var editoras = new List<EditoraViewModel>
            {
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                }
            };

            var resultado = responseFormatter.FormatarResposta(TipoRequisicao.Get, editoras);
            resultado.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(editoras);

            resultado.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.OK);
        }

        [Fact]
        public void FormatarResposta_TipoRequisicao_POST()
        {
            var notificador = new Notificador();
            var formatter = new ResponseFormatter(notificador);
            var editora =
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                };

            var resultado = formatter.FormatarResposta(TipoRequisicao.Post, editora);
            
            resultado.Should().BeOfType<CreatedAtRouteResult>()
                .Which.Value.Should().BeEquivalentTo(editora);
            
            resultado.Should().BeOfType<CreatedAtRouteResult>()
                .Which.RouteName.Should().Be("Get");

            resultado.Should().BeOfType<CreatedAtRouteResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.Created);
        }
        
        [Fact]
        public void FormatarResposta_TipoRequisicao_PUT()
        {
            var notificador = new Notificador();
            var formatter = new ResponseFormatter(notificador);
            var editora =
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                };

            var resultado = formatter.FormatarResposta(TipoRequisicao.Put, editora);
            
            resultado.Should().BeOfType<AcceptedAtRouteResult>()
                .Which.Value.Should().BeEquivalentTo(editora);

            resultado.Should().BeOfType<AcceptedAtRouteResult>()
                .Which.RouteName.Should().Be("Get");

            resultado.Should().BeOfType<AcceptedAtRouteResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.Accepted);
        }
        
        [Fact]
        public void FormatarResposta_TipoRequisicao_PATCH()
        {
            var notificador = new Notificador();
            var formatter = new ResponseFormatter(notificador);
            var editora =
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                };

            var resultado = formatter.FormatarResposta(TipoRequisicao.Patch, editora);
            
            resultado.Should().BeOfType<AcceptedAtRouteResult>()
                .Which.Value.Should().BeEquivalentTo(editora);
            
            resultado.Should().BeOfType<AcceptedAtRouteResult>()
                .Which.RouteName.Should().Be("Get");

            resultado.Should().BeOfType<AcceptedAtRouteResult>()
                .Which.StatusCode.Should().Be((int) HttpStatusCode.Accepted);
        }
        
        [Fact]
        public void FormatarResposta_TipoRequisicao_DELETE()
        {
            var notificador = new Notificador();
            var formatter = new ResponseFormatter(notificador);
            var editora =
                new EditoraViewModel
                {
                    Id = 1,
                    Nome = "Editora",
                    Email = "editora@editora.com",
                    Pais = "Brasil"
                };

            var resultado = formatter.FormatarResposta(TipoRequisicao.Delete, editora);
            
            resultado.Should().BeOfType<NoContentResult>();
        }
    }
}