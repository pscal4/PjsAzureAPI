using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace PJSAzure.API
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

            services.AddSwaggerGen();
            //services.AddSwaggerGen(c =>
            //{
            //    var provider = services.BuildServiceProvider()
            //        .GetRequiredService<IApiVersionDescriptionProvider>();

            //    foreach (var description in provider.ApiVersionDescriptions)
            //    {
            //        c.SwaggerDoc(
            //            description.GroupName,
            //            new Info()
            //            {
            //                Title = $"FSI.FoundationAccess.Api {description.ApiVersion}",
            //                Version = description.ApiVersion.ToString(),
            //                Description = "FSI Foundation Access"
            //            });
            //    }

            //    var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            //    c.IncludeXmlComments(System.IO.Path.Combine(baseDirectory, "FSI.FoundationAccess.Api.xml"));
            //    c.CustomSchemaIds(x => x.FullName);
            //    c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
            //    {
            //        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
            //        Name = "Authorization",
            //        In = "header",
            //        Type = "apiKey"
            //    });
            //    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
            //    {
            //        { "Bearer", new string[] { } }
            //    });
            //});

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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PJS Azure V1");
                c.DocumentTitle = "PJS Azure Api";
                
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
