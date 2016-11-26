using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuizApp.Database;
using System;
using System.IO;

namespace QuizApp
{
    public class Startup
    {
        public IConfiguration Config { get; private set; }
        private bool isDevelopment;
        public void Configure(IHostingEnvironment env)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("config.json")
               .Build();
            isDevelopment = (Config["IsDevelopment"] != null);
        }

        public void ConfigureServices(IServiceCollection services, IHostingEnvironment env)
        {
            services.AddDbContext<QuizDbContext>(options => options.UseSqlServer(/*(isDevelopment) ? Config["ConnectionStrings:LocalConnection"] : Config["ConnectionStrings:ServerConnection"])*/@"Data Source=DESKTOP-Q2LUF87\SQLEXPRESS;Initial Catalog=RSC2016Test;Integrated Security=True"));
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
