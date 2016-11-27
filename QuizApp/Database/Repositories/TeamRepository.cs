using Microsoft.EntityFrameworkCore;
using QuizApp.Database.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QuizApp.Database.Repositories
{
    public class TeamRepository
    {
        private QuizDbContext _context;

        public TeamRepository(QuizDbContext Context)
        {
            _context = Context;
        }

        internal ICollection<Team> GetAll()
        {
            return _context.Teams
                 .Include(x => x.TeamMembers)
                     .ThenInclude(x => x.User)
                 .Include(x => x.Events)
                     .ThenInclude(x => x.Event)
                 .ToList();
        }

        internal Team GetById(int id)
        {
            return _context.Teams.SingleOrDefault(x => x.ID == id);
        }

        internal Team CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team;

        }

        internal object JoinTeam(int teamid, int userid)
        {
            var TeamUser = new TeamUser { UserId = userid, TeamId = teamid };
            _context.TeamUsers.Add(TeamUser);
            _context.SaveChanges();
            return TeamUser;
        }
    }
}
