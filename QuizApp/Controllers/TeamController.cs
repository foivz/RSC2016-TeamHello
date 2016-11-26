//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using QuizApp.Database.Repositories;

//namespace QuizApp.Controllers
//{
//    [Authorize]
//    [Route("api/team")]
//    public class TeamController : Controller
//    {
//        private TeamRepository _repo;


//        public TeamController(TeamRepository repo)
//        {
//            _repo = repo;
//        }

//        [HttpGet("all")]
//        public JsonResult GetAll()
//        {
//            return new JsonResult(_repo.GetAll());
//        }

//        [HttpPost("create")]
//        public string CreateTeam()
//        {

//        }
//    }
//}
