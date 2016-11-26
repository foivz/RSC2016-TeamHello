using QuizApp.Database.Model;
using QuizApp.Database.Model.Base;

namespace QuizApp.Database
{
    public class TeamUser : ModelBase
    {
        public int? TeamId { get; set; }
        public int? UserId { get; set; }

        public Team Team { get; set; }
        public User User { get; set; }
    }
}
