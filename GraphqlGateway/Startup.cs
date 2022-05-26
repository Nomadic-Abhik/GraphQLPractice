using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlGateway
{
    public class Startup
    {
        public const string API1 = "GraphQLPractice";
        public const string API2 = "SecondGraphQLAPI";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient(API1, c => c.BaseAddress = new Uri("http://localhost:27888/graphql"));
            services.AddHttpClient(API2, c => c.BaseAddress = new Uri("http://localhost:52356/graphql"));
            services
                .AddGraphQLServer()
                .AddRemoteSchema(API1)
                .AddRemoteSchema(API2);
            #region WIP
            //.AddRemoteSchema(API1,ignoreRootTypes:true)
            //.AddRemoteSchema(API2, ignoreRootTypes: true)
            //.AddTypeExtensionsFromFile("../" + API1 + "/GraphQL/Stiching.graphql");
            #endregion
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphqlGateway", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphqlGateway v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}
