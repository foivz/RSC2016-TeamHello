using QuizApp.Database.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database.Model
{
    public class UserAnswer : ModelBase
    {
        public string Input { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
