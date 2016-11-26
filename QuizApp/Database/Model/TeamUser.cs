using QuizApp.Database.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database
{
    public class TeamUser
    {
        public int? TeamId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
