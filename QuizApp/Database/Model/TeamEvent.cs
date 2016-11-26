using QuizApp.Database.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database.Model
{
    public class TeamEvent : ModelBase
    {
        public int EventId { get; set; }
        public int TeamId { get; set; }

        public Team Team { get; set; }
        public Event Event { get; set; }
    }
}
