using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Assignment_6.Services;

namespace Assignment_6 {
    public class Startup {

        public Startup(IHostingEnvironment env) { }

        public void ConfigureServices(IServiceCollection services) {
            services.AddScoped<StopwatchService>();
            services.AddSingleton<IDatabase, MemoryDatabase>();
            services.AddTransient<IRequestIdGenerator, GuidRequestIdGenerator>();
            services.AddInstance<ILogger>(ConsoleLogger.Instance);
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseCors(policy => policy
                .WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders(new string[] {
                    "request-id",
                    "stopwatch"
                }));

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
