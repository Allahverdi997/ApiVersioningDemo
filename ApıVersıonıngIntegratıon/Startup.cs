using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıVersıonıngIntegratıon
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ApiVersioning.WebApi", Version = "v1" });
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ApiVersioning.WebApi", Version = "v2" });
            });

            services.AddApiVersioning(s=> {
                s.DefaultApiVersion = new ApiVersion(1, 0);
                s.AssumeDefaultVersionWhenUnspecified = true;
                s.ReportApiVersions = true;
                s.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("x-api-version"), new MediaTypeApiVersionReader("x-api-version"));
            });
            services.AddVersionedApiExplorer(s=>
            {
                s.GroupNameFormat = "'v'VVV";
                s.SubstituteApiVersionInUrl = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiVersioning.WebApi v1");c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "ApiVersioning.WebApi v2"); c.RoutePrefix = string.Empty;
                }) ;
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
