using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizApp.Database.Model;

namespace QuizApp.Database
{
    public class AnswerRepository
    {
        private QuizDbContext _context;

        public AnswerRepository(QuizDbContext Context)
        {
            _context = Context;
        }

        public int CreateAnswer(Answer answer)
        {

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return answer.ID;
        }

        public Answer GetAnswer(int ID)
        {
            var answer = _context.Answers.Include(x => x.Question).FirstOrDefault(x => x.ID == ID);

            return answer;
        }

        public ICollection<Answer> GetAllAnswers()
        {
            var answers = _context.Answers.Include(x => x.Question).ToList();

            return answers;
        }
    }
}
