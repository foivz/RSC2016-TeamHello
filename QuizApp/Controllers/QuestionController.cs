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
    [Route("api/question")]
    public class QuestionController : Controller
    {
        QuestionRepository _repo;
        AnswerRepository _answerRepo;
        private int _userid;
        public QuestionController([FromBody]QuestionRepository repo, AnswerRepository answerRepo)
        {
            _repo = repo;
            _answerRepo = answerRepo;
            _userid = Convert.ToInt32(User.Claims.Where(x => x.Type == "UserID").SingleOrDefault().Value);
        }

        [HttpPost("create")]
        public void Create(ICollection<Question> Questions)
        {
            int questionID;
            // _repo.CreateQuestion(Question);
            foreach (Question question in Questions)
            {
                questionID = _repo.CreateQuestion(question);
                foreach(Answer answer in question.Answers)
                {
                    answer.QuestionId = questionID;
                    _answerRepo.CreateAnswer(answer);
                }
            }
        }

        [HttpGet("{id}")]
        public Question Get(int id)
        {
            return _repo.GetQuestion(id);
        }

        public JsonResult GetAll()
        {
            ICollection<Question> questions = _repo.GetAllQuestions();
            return new JsonResult(questions);
        }
    }
}
