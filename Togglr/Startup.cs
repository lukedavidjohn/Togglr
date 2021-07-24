using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Togglr.Controllers;
using Togglr.Models;
using Togglr.Services;

namespace Togglr
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
            services.AddHttpClient();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Togglr", Version = "v1" });
            });
            services.AddScoped<ITogglDataService<Project>, ProjectService>();
            services.AddScoped<ITogglDataService<Tag>, TagService>();
            services.AddScoped<ITogglDataService<Task>, TaskService>();
            // var endPointA = new Uri("http://localhost:58919/"); // this is the endpoint HttpClient will hit
            // HttpClient httpClient = new()
            // {
            //     BaseAddress = endPointA,
            // };

            // ServicePointManager.FindServicePoint(endPointA).ConnectionLeaseTimeout = 60000; // sixty seconds

            // services.AddSingleton<HttpClient>(httpClient); // note the singleton
            // services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Togglr v1"));
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
