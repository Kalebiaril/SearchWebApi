using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SearchWebApi.Clients;
using SearchWebApi.DB;
using SearchWebApi.Interfaces;
using SearchWebApi.Providers;

namespace SearchWebApi
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
            services.AddScoped<ISearchProvider, SearchProvider>();
            services.AddScoped<IGoogleSearchClient, GoogleSearchClient>();
            services.AddScoped<IBingSearchClient, BingSearchClient>();
            services.AddAutoMapper(typeof(Startup));
            var connectionString = Configuration["ConnectionStrings:Default"];
            services.AddDbContext<SearchApiDbContext>(options =>
                options.UseSqlServer.Use(connectionString),
                ServiceLifetime.Transient);
            services.AddControllers();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
