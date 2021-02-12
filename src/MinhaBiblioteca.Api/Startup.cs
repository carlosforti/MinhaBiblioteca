using MinhaBiblioteca.Api.Formatter;
using MinhaBiblioteca.Application.Configurations;
using MinhaBiblioteca.Infra.Shared.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MinhaBiblioteca.Infra.Data.Configurations;

namespace MinhaBiblioteca.Api
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
            services.AddControllers();
            services
                .AddScoped<IResponseFormatter, ResponseFormatter>()
                .AddLogging(options =>
                {
                    options.AddConsole(configure =>
                    {
                        configure.DisableColors = false;
                    });
                })
                .ConfigurarInfraData(Configuration)
                .ConfigureShared()
                .ConfigurarAutoMapper()
                .ConfigurarUseCases(Configuration)
                .AddApiVersioning(config =>
                {
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    config.ReportApiVersions = true;
                })
                .AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha Biblioteca V1");
                c.RoutePrefix = "";
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
