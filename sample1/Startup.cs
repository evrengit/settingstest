using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace sample1
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
            // Prefer connection string from Azure App Service's special tab ("Connection strings")
            // Environment variable will be named: SQLCONNSTR_<name> (e.g., SQLCONNSTR_DefaultConnection)
            string azureSqlConnectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_DefaultConnection");
            if (string.IsNullOrEmpty(azureSqlConnectionString))
            {
                // Fallback to appsettings.json or other configuration
                azureSqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            }
            // Example usage: services.AddDbContext<MyDbContext>(options => options.UseSqlServer(azureSqlConnectionString));


Console.WriteLine($"Using connection string: {azureSqlConnectionString}");
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "sample1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "sample1 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
