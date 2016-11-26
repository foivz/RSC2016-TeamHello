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
    [Route("api/answers")]
    public class AnswerController : Controller
    {
        AnswerRepository _repo;
        private int _userid;
        public AnswerController(AnswerRepository repo)
        {
            _repo = repo;
            _userid = Convert.ToInt32(User.Claims.Where(x => x.Type == "UserID").SingleOrDefault().Value);
        }

        [HttpPost("create")]
        public int Create([FromBody]Answer Answer)
        {
            return _repo.CreateAnswer(Answer);
        }

        [HttpGet("{id}")]
        public Answer Get(int id)
        {
            return _repo.GetAnswer(id);
        }

        public JsonResult GetAllByQuestion(int questionID)
        {
            ICollection<Answer> answers = _repo.GetAllAnswers().Where(x => x.QuestionId == questionID).ToList();
            return new JsonResult(answers);
        }
    }
}
