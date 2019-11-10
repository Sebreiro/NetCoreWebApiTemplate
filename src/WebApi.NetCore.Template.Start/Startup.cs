using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using WebApi.NetCore.Template.DAL;
using WebApi.NetCore.Template.Start.Initialization;

namespace WebApi.NetCore.Template.Start
{
    public class Startup
    {
        public const string ConfigFolder = "Config";

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"{ConfigFolder}/appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{ConfigFolder}/appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("Postgres"),
                        b => b.MigrationsAssembly("WebApi.NetCore.Template.DAL"));
                }
            );

            OptionsInitialization.Initialize(services, Configuration);

            services.AddControllers();

            ContainerConfiguration.Initialize(services);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "My API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();
            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            DataBaseInitialization.Initialize(app.ApplicationServices);
        }
        
    }
}