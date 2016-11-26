using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database.Model
{
    public class TeamEvent
    {
        public int? EventId { get; set; }
        public int? TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
