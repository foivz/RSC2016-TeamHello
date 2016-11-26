using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuizApp.Database.Model;

namespace QuizApp.Database
{
    public class UserAnswerRepository
    {
        private QuizDbContext _context;

        public UserAnswerRepository(QuizDbContext Context)
        {
            _context = Context;
        }

        public int CreateUserAnswer(UserAnswer answer)
        {

            _context.UserAnswers.Add(answer);
            _context.SaveChanges();

            return answer.ID;
        }

        public UserAnswer GetUserAnswer(int ID)
        {
            var answer = _context.UserAnswers.Include(x => x.Question).Include(x => x.User).FirstOrDefault(x => x.ID == ID);

            return answer;
        }

        public ICollection<UserAnswer> GetAllUserAnswers()
        {
            var answers = _context.UserAnswers.Include(x => x.Question).Include(x => x.User).ToList();

            return answers;
        }
    }
}
