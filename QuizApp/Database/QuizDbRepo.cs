using QuizApp.Controllers.Requests;
using QuizApp.Database.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Database
{
    public partial class QuizDbRepo
    {
        private QuizDbContext _context;

        public QuizDbRepo(QuizDbContext Context)
        {
            _context = Context;
        }

        internal User GetUser(LoginRequest Req)
        {
            User user;

            if(_context.Users.Any(x => x.UID == Req.uid && x.Vendor == Req.provider))
            {
                user = _context.Users.Single(x => x.UID == Req.uid && x.Vendor == Req.provider);
            }
            else
            {
                user = new User { Email = Req.email, Name = Req.name, UID = Req.uid, Vendor = Req.provider };
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            return user;
        }

        internal User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.ID == id);
        }

        internal int CreateEvent(Event _event)
        {
            _context.Events.Add(_event);
            _context.SaveChanges();
            return _event.ID;
           
        }

        internal int Edit(Event _event)
        {
            var dbevent = _context.Events.SingleOrDefault(x => x.ID == _event.ID);
            dbevent.Name = _event.Name;
            dbevent.IsActive = _event.IsActive;
            dbevent.Location = _event.Location;
            dbevent.Description = _event.Description;
            dbevent.Rules = _event.Rules;
            dbevent.Prizes = _event.Prizes;
            _context.SaveChanges();
            return dbevent.ID;
        }

        internal ICollection<Event> GetAllUserUpcommingEvents(int userid)
        {
            return GetAllUserEvents(userid).Where(x => x.Date > DateTime.Now).ToList();
        }

        internal ICollection<Event> GetAllUserCompletedEvents(int userid)
        {
            return GetAllUserEvents(userid).Where(x => x.Date < DateTime.Now).ToList();
        }

        internal Event GetEvent(int id)
        {
            return _context.Events.Single(x => x.ID == id);
        }

        internal ICollection<Event> GetEventsByModerator(int modID)
        {
            return GetAllEvents().Where(x => x.ModeratorId == modID).ToList();
        }

        internal ICollection<Event> GetAllEvents()
        {
            return _context.Events
                .Include(x => x.Moderator)
                .Include(x => x.Questions)
                    .ThenInclude(q => q.UserAnswers)
                .Include(x => x.TeamEvent)
                    .ThenInclude(t => t.Team)
                        .ThenInclude(t => t.TeamMembers)
                .ToList();
        }

        internal ICollection<Event> GetAllUserEvents(int userID)
        {
            return GetAllEvents().Where(x => x.TeamEvent.Any(y => y.Team.TeamMembers.Any(z => z.ID == userID))).ToList();
        }

        internal ICollection<Event> GetAllModeratedEvents(int userid)
        {
            return GetAllEvents().Where(x => x.ModeratorId == userid).ToList();
        }

        internal ICollection<Event> GetAllActiveEvents()
        {
            return GetAllEvents().Where(x => x.IsActive).ToList();
        }

        internal ICollection<Event> GetAllUpcommingModeratedEvents(int userid)
        {
            return GetAllModeratedEvents(userid).Where(x => x.Date > DateTime.Now).ToList();
        }

        internal ICollection<Event> GetAllCompletedEventsByMod(int userid)
        {
            return GetAllModeratedEvents(userid).Where(x => x.Date < DateTime.Now).ToList();
        }

        internal ICollection<Event> GetAllUpcommingEvents()
        {
            return GetAllEvents().Where(x => x.Date > DateTime.Now).ToList();
        }

        internal ICollection<Event> GetAllCompletedEvents()
        {
            return GetAllEvents().Where(x => x.Date < DateTime.Now).ToList();
        }
    }
}
