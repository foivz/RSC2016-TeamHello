using Microsoft.AspNetCore.Builder;

namespace QuizApp.Middleware
{

    public static class CustomAuthenticationExtension
    {
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthentificationMiddleware>();
        }
    }
}
