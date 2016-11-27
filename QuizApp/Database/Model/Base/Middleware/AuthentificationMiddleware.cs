using Evidencija.Auth;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace QuizApp.Middleware
{
    internal class AuthentificationMiddleware
    {
        private RequestDelegate _next;

        private JwtTokenProvider _provider;

        public AuthentificationMiddleware(RequestDelegate next, JwtTokenProvider provider)
        {
            _provider = provider;

            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].ToString();

            if(token != "")
            {
                var ClaimsPrincipal = _provider.Validate(token);
                context.User = ClaimsPrincipal;
            }

            await _next(context);

            return;
        }
    }
}