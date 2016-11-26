using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuizApp.Database;
using System.IO;

namespace QuizApp
{
    public class Startup
    {
        public IConfiguration Config { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("config.json")
               .AddEnvironmentVariables()
               .Build();
            Config["IsDev"] = env.IsDevelopment().ToString();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<QuizDbContext>(options => options.UseSqlServer((Config["IsDev"] == "True") ? Config["ConnectionStrings:LocalConnection"] : Config["ConnectionStrings:ServerConnection"]));
            services.AddSingleton<IConfiguration>(Config);
            services.AddMvc();
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
            app.UseMvc();
        }
    }
}
