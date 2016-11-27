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
        public JsonResult Login([FromBody]LoginRequest req)
        {
            var user = _repo.GetUser(req);

            return new JsonResult(user);
        }
    }
}
