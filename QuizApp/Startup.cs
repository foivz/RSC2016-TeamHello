using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace QuizApp
{
    public class Startup
    {
        public IConfiguration Config { get; private set; }
        public void Configure(IHostingEnvironment env)
        {
             Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services, IHostingEnvironment env)
        {
            services.AddDbContext<>(options => options.UseSqlServer((env.IsDevelopment()) ? Config["ConnectionStrings:LocalConnection"] : Config["ConnectionStrings:ServerConnection"]));
            services.AddSingleton<IConfiguration>(Config);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
