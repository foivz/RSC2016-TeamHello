using QuizApp.Controllers.Requests;
using QuizApp.Database.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Database
{
    public class QuizDbRepo
    {
        private QuizDbContext _context;

        public QuizDbRepo(QuizDbContext Context)
        {
            _context = Context;
        }

        internal User GetUser(LoginRequest Req)
        {
            return _context.Users.Where(x => x.UID == Req.uid && x.Vendor == Req.vendor).SingleOrDefault();
            
        }

        internal User AddUser(LoginRequest Req)
        {
            var user = new User { Email = Req.email, Name = Req.name, Nick = Req.nick, UID = Req.uid, Vendor = Req.vendor };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;

        }

        internal Event CreateEvent(Event Event,int userid)
        {
            Event.ModeratorId = userid;
            _context.Events.Add(Event);
            _context.SaveChanges();
            return Event;
           
        }

        internal Event Modify(Event Event)
        {
            var dbevent = _context.Events.SingleOrDefault(x => x.ID == Event.ID);
            dbevent.Name = Event.Name;
            dbevent.IsActive = Event.IsActive;
            dbevent.Location = Event.Location;
            dbevent.Description = Event.Description;
            dbevent.Rules = Event.Rules;
            dbevent.Prizes = Event.Prizes;
            _context.SaveChanges();
            return dbevent;
        }

        internal Event GetEvent(int id)
        {
            var Event = _context.Events
                .Include(x => x.Moderator)
                .Include(x => x.Questions)
                    .ThenInclude(q => q.UserAnswers)
                .Include(x => x.TeamEvent)
                    .ThenInclude(t => t.Team)
                        .ThenInclude(t => t.TeamMembers)
                .Single(x => x.ModeratorId == id);

            return Event;
        }

        internal ICollection<Event> GetAllEvents(int userid)
        {
            var 
            return 
        }

        internal ICollection<Event> GetAllModeratedEvents(int _userid)
        {
            throw new NotImplementedException();
        }

        internal Event Modify(Event Event,int userid)
        {
            throw new NotImplementedException();
        }

        internal ICollection<Event> GetAllCompletedEvents(int _userid)
        {
            throw new NotImplementedException();
        }
    }
}
