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
                 //.Include(x => x.Captain)
                 .Include(x => x.TeamMembers)
                     .ThenInclude(x => x.User)
                 .Include(x => x.Events)
                     .ThenInclude(x => x.Event)
                 .ToList();
        }

        internal void CreateTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
