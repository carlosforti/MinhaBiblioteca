using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MinhaBiblioteca.API.Formatter;
using MinhaBiblioteca.Application.Configurations;
using MinhaBiblioteca.Infra.Data.Configurations;
using MinhaBiblioteca.Infra.Data.Context;
using MinhaBiblioteca.Infra.Shared.Configurations;

namespace MinhaBiblioteca.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ApiVersion apiVersion = GetApiVersion(Configuration);

            services.AddControllers()
                .AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });

            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = apiVersion;
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
                p.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
                p.DefaultApiVersion = apiVersion;
            });

            services
                .AddScoped<IResponseFormatter, ResponseFormatter>()
                .AddLogging(options => { options.AddConsole(); })
                .ConfigurarInfraData(Configuration)
                .ConfigureShared()
                .ConfigurarAutoMapper()
                .ConfigurarAutoMapperData()
                .ConfigurarUseCases(Configuration)
                .AddApiVersioning(config =>
                {
                    config.DefaultApiVersion = apiVersion;
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    config.ReportApiVersions = true;
                })
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Minha Biblioteca - V1", Version = "v1"});
                    c.SwaggerDoc("v2", new OpenApiInfo {Title = "Minha Biblioteca - V2", Version = "v2"});
                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
        }

        private ApiVersion GetApiVersion(IConfiguration configuration)
        {
            var major = Configuration["ApiVersionDefault:Major"];
            var minor = Configuration["ApiVersionDefault:Minor"];

            if (!int.TryParse(major, out var majorVersion))
                majorVersion = 1;

            if (!int.TryParse(minor, out var minorVersion))
                minorVersion = 0;

            return new ApiVersion(majorVersion, minorVersion);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }

                c.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}