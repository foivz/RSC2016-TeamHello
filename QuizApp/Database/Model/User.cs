using QuizApp.Database.Model.Base;
using System.Collections.Generic;

namespace QuizApp.Database.Model
{
    public class User : ModelBase
    {
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public string UID { get; set; }

        public ICollection<TeamUser> Teams { get; set; }
        public ICollection<Event> ModedEvents { get; set; }
        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
