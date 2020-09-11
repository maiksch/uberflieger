using Application.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using HotChocolate;
using HotChocolate.AspNetCore;
using Web.GraphQL.Types;
using HotChocolate.Execution.Configuration;
using HotChocolate.AspNetCore.Voyager;

namespace Web
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            services.AddControllers();

            services.AddApplication(Configuration);

            services.AddPersistence(Configuration);

            services.AddGraphQL(sp => 
                SchemaBuilder.New()
                             .AddQueryType<QueryType>()
                             .AddType<ProductType>()
                             .AddType<ModuleType>()
                             .AddType<LessonType>()
                             .AddType<ImageType>()
                             .AddType<VideoType>()
                             .Create(),
                // to fix System.InvalidOperationException
                new QueryExecutionOptions { ForceSerialExecution = true }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UsePlayground()
                    .UseVoyager();
            }

            app
                //.UseHttpsRedirection()
                .UseRouting()
                .UseCors()
                .UseAuthorization()
                .UseGraphQL("/graphql")
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            //using var scope = app.ApplicationServices.CreateScope();
            //using var context = scope.ServiceProvider.GetService<UberfliegerContext>();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
        }
    }
}
