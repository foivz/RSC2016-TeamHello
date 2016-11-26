using QuizApp.Database.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Database.Model
{
    public class Team : ModelBase
    {
        public string Name { get; set; }
        public int CaptainId { get; set; }

        public ICollection<TeamEvent> Events { get; set; }
        public ICollection<TeamUser> TeamMembers { get; set; }
    }
}
