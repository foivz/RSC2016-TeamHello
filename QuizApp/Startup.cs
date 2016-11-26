using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuizApp.Database;
using QuizApp.Middleware;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Evidencija.Auth;
using Evidencija.Encription;
using QuizApp.Database.Repositories;

namespace QuizApp
{
    public class Startup
    {
        public IConfiguration Config { get; private set; }

        private SecurityKey _RSAKey { get; set; }

        private TokenAuthenticationOptions _tokenOptions { get; set; }


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
              services.AddAuthorization(auth =>
              {
                  auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                      .RequireAuthenticatedUser().Build();
              });

            _RSAKey = new RsaSecurityKey(RSAKeyUtils.GetRandomKey());

              _tokenOptions = new TokenAuthenticationOptions
              (
                  Audience: "QuizUsers",
                  Issuer: "QuizApp",
                  SigningCredentials: new SigningCredentials(_RSAKey, SecurityAlgorithms.RsaSha256Signature)
              );

            services.AddDbContext<QuizDbContext>(options => options.UseSqlServer((Config["IsDev"] == "True") ? Config["ConnectionStrings:LocalConnection"] : Config["ConnectionStrings:ServerConnection"]));
            services.AddSingleton<TokenAuthenticationOptions>(_tokenOptions);
            services.AddSingleton<JwtTokenProvider>();
            services.AddSingleton<IConfiguration>(Config);
            services.AddScoped<QuizDbRepo>();
            services.AddScoped<QuestionRepository>();
            services.AddScoped<AnswerRepository>();
            services.AddScoped<TeamRepository>();
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
            app.UseCustomAuthentication();
            app.UseMvc();
        }
    }
}
