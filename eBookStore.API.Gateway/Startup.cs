using eBookStore.API.Gateway.MessageHandler;
using eBookStore.API.Gateway.RemoteInterface.Author;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

using System;

namespace eBookStore.API.Gateway
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
            services.AddHttpClient("author-service", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Author"]);
            });

            services.AddSingleton<IAuthorRemote, AuthorRemote>();
            services.AddOcelot()
                .AddDelegatingHandler<BookHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            System.Threading.Thread.Sleep(1000 * 5);

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOcelot().Wait();
        }
    }
}
