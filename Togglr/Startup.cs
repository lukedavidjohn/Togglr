using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Togglr.Models;
using Togglr.Services;
using Togglr.Utilities;

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
            services.AddSingleton<ITogglDataService<Project>, ProjectService>();
            services.AddSingleton<ITogglDataService<Tag>, TagService>();
            services.AddSingleton<ITogglDataService<Task>, TaskService>();
            services.AddSingleton<ITimeEntryService, TimeEntryService>();
            services.AddSingleton<IStreamReaderUtility, StreamReaderUtility>();
            services.AddSingleton<IFetchUtility, FetchUtility>();
            services.AddSingleton(typeof(IPostUtility<>), typeof(PostUtility<>));
            services.AddSingleton(typeof(IJsonLoaderFromFile<>), typeof(JsonLoaderFromFile<>));
            services.AddSingleton(typeof(IJsonLoaderFromWeb<>), typeof(JsonLoaderFromWeb<>));
            services.AddSingleton<IDeserializer, Deserializer>();
            services.AddMvc();
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
