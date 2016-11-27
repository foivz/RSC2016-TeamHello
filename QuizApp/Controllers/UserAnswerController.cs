using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Database;
using QuizApp.Database.Model;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections;
using System.Collections.Generic;

namespace QuizApp.Controllers.Requests
{
    [Authorize]
    [Route("api/userAnswers")]
    public class UserAnswerController : Controller
    {
        UserAnswerRepository _repo;
        public UserAnswerController(UserAnswerRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("create")]
        public int Create([FromBody]UserAnswer UserAnswer)
        {
            return _repo.CreateUserAnswer(UserAnswer);
        }

        [HttpGet("{id}")]
        public UserAnswer Get(int id)
        {
            return _repo.GetUserAnswer(id);
        }

        public JsonResult GetAllByUser(int userID)
        {
            ICollection<UserAnswer> userAnswers = _repo.GetAllUserAnswers().Where(x => x.UserId == userID).ToList();
            return new JsonResult(userAnswers);
        }
    }
}
