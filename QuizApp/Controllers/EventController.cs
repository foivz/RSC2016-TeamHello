using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Database;
using QuizApp.Database.Model;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace QuizApp.Controllers.Requests
{
    [Authorize]
    [Route("api/event")]
    public class EventController : Controller
    {
        QuizDbRepo _repo;
        private int _userid;
        public EventController(QuizDbRepo repo)
        {
            _repo = repo;
            _userid = Convert.ToInt32(User.Claims.Where(x => x.Type == "UserID").SingleOrDefault().Value);
        }

        [HttpPost("create")]
        public Event Create([FromBody]Event Event)
        {
            return _repo.CreateEvent(Event, _userid);
        }

        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _repo.GetEvent(id);
        }

        [HttpPut("edit")]
        public Event Edit([FromBody]Event Event)
        {
            return _repo.Modify(Event);
        }

        [HttpGet("getall")]
        public JsonResult GetAll()
        {
            ICollection<Event> events = _repo.GetAllEvents();
            return new JsonResult(events);
        }

        [HttpGet("getmoderator")]
        public JsonResult GetByModerator()
        {
            ICollection<Event> events = _repo.GetAllModeratedEvents(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getmoderatorupcomming")]
        public JsonResult GetByModeratorUpcomming()
        {
            ICollection<Event> events = _repo.GetAllUpcommingModeratedEvents(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getmoderatorcomplete")]
        public JsonResult GetByModeratorComplete()
        {
            ICollection<Event> events = _repo.GetAllCompletedEventsByMod(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getallupcomming")]
        public JsonResult GetAllUpcomming()
        {
            ICollection<Event> events = _repo.GetAllUpcommingEvents();
            return new JsonResult(events);
        }

        [HttpGet("getallcompleted")]
        public JsonResult GetAllCompleted()
        {
            ICollection<Event> events = _repo.GetAllCompletedEvents();
            return new JsonResult(events);
        }

        [HttpGet("getalluserparticipat")]
        public JsonResult GetAllUserEventsParticipant()
        {
            ICollection<Event> events = _repo.GetAllUserEvents(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getalluser")]
        public JsonResult GetAllUserEvents()
        {
            List<Event> events = _repo.GetAllUserEvents(_userid).ToList();
            events.AddRange(_repo.GetAllModeratedEvents(_userid));
            return new JsonResult(events);
        }

        [HttpGet("getallusercompleted")]
        public JsonResult GetAllUserCompleted()
        {
            ICollection<Event> events = _repo.GetAllUserCompletedEvents(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getallupcomming")]
        public JsonResult GetAllUserUpcomming()
        {
            ICollection<Event> events = _repo.GetAllUserUpcommingEvents(_userid);
            return new JsonResult(events);
        }

        [AllowAnonymous]
        [HttpGet("getallactive")]
        public JsonResult IsActive()
        {
            ICollection<Event> events = _repo.GetAllActiveEvents();
            return new JsonResult(events);
        }
    }
}
