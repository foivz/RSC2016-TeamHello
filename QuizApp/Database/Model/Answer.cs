using QuizApp.Database.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database.Model
{
    public class Answer : ModelBase
    {
        public string Input { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}