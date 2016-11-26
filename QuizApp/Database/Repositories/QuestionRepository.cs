using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuizApp.Database.Model;

namespace QuizApp.Database
{
    public class QuestionRepository
    {
        private QuizDbContext _context;

        public QuestionRepository(QuizDbContext Context)
        {
            _context = Context;
        }

        public int CreateQuestion(Question question)
        {

            _context.Questions.Add(question);
            _context.SaveChanges();

            return question.ID;
        }

        public Question GetQuestion(int ID)
        {
            var question = _context.Questions.Include(x => x.Event).Include(x => x.Answers).Include(x => x.UserAnswers).FirstOrDefault(x => x.ID == ID);

            return question;
        }

        public ICollection<Question> GetAllQuestions()
        {
            var questions = _context.Questions.Include(x => x.Event).Include(x => x.Answers).Include(x => x.UserAnswers).ToList();

            return questions;
        }
    }
}
