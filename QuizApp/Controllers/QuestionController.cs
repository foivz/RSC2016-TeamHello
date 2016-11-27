using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Database;
using QuizApp.Database.Model;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace QuizApp.Controllers.Requests
{
    [Route("api/questions")]
    public class QuestionController : Controller
    {
        QuestionRepository _repo;
        AnswerRepository _answerRepo;
        public QuestionController([FromBody]QuestionRepository repo, AnswerRepository answerRepo)
        {
            _repo = repo;
            _answerRepo = answerRepo;
        }

        [HttpPost("create")]
        public void Create([FromBody]ICollection<Question> Questions)
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

                    if (question.Type == 2 || question.Type == 3)
                    {
                        answer.IsCorrect = true;
                    }
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
