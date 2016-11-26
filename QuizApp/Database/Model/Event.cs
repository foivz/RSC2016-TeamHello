using QuizApp.Database.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database.Model
{
    public class Event : ModelBase
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ModeratorId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ModeratorId")]
        public User Moderator { get; set; }
        public ICollection<TeamEvent> TeamEvent { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
