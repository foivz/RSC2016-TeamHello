using QuizApp.Database.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database.Model
{
    public class Event : ModelBase
    {
        public string Nick { get; set; }
        public string Email { get; set; }
        public int ModeratorId { get; set; }

        [ForeignKey("ModeratorId")]
        public User Moderator { get; set; }
        public ICollection<TeamEvent> Teams { get; set; }
        public ICollection<Event> ModEvents { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
