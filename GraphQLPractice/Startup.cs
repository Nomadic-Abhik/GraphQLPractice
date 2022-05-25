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
using System.Configuration;
using GraphQLPractice.DataAccess;
using GraphQLPractice.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
//using GraphQLPractice.DataAccess.DAO;
//using GraphQL.Server.Ui.Voyager;
using HotChocolate.AspNetCore.Voyager;
using GraphQLPractice.GraphQL;
using GraphQLPractice.GraphQL.Types;

namespace GraphQLPractice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<GraphQlDbContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("DevConnection")));
            services.AddControllers();
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections()
               //.AddType<PlatformType>()
                //.AddType<CommandType>()
                .AddFiltering()
                .AddSorting();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLPractice", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLPractice v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
            app.UseVoyager(new VoyagerOptions()
            {
                QueryPath = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}
