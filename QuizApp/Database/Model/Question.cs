using QuizApp.Database.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database.Model
{
    public class Question : ModelBase
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }

    }
}