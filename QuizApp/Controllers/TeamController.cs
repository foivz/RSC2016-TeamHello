using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Database.Model;
using QuizApp.Database.Repositories;

namespace QuizApp.Controllers
{
    [Route("api/teams")]
    public class TeamController : Controller
    {
        private TeamRepository _repo;

        public TeamController(TeamRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("get/{id}")]
        public JsonResult GetAll(int id)
        {
            return new JsonResult(_repo.GetById(id));
        }

        [HttpGet("getAll")]
        public JsonResult GetAll()
        {
            return new JsonResult(_repo.GetAll());
        }

        [HttpPost("create")]
        public JsonResult CreateTeam([FromBody]Team team)
        {
            var createdTeam =_repo.CreateTeam(team);
            return new JsonResult(createdTeam);
        }

        [HttpPost("join/{teamid}/{userid}")]
        public JsonResult CreateTeam(int teamid, int userid)
        {
            var joinTeam = _repo.JoinTeam(teamid, userid);
            return new JsonResult(joinTeam);
        }
    }
}
