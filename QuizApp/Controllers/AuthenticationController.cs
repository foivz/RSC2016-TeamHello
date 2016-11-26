using Evidencija.Auth;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Controllers.Requests;
using QuizApp.Database;
using QuizApp.Database.Model;

namespace QuizApp.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        private QuizDbRepo _repo;

        private JwtTokenProvider _tokenProvider;

        public AuthenticationController(QuizDbRepo repo, JwtTokenProvider provider)
        {
            _tokenProvider = provider;
            _repo = repo;
        }

        [HttpPost("login")]
        public string Login([FromBody]LoginRequest req)
        {
            var user = _repo.GetUser(req);
            if (user == default(User)) return "";

            var token = _tokenProvider.Create(user, 6000).Token;

            return token;
        }

        [HttpPost("register")]
        public string Register([FromBody]LoginRequest req)
        {
            var user = _repo.AddUser(req);
            var token = _tokenProvider.Create(user, 6000).Token;

            return token;
        }
    }
}
