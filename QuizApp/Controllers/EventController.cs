using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Database;
using QuizApp.Database.Model;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections;
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

        public Event Edit([FromBody]Event Event)
        {
            return _repo.Modify(Event);
        }

        public JsonResult GetAll()
        {
            ICollection<Event> events = _repo.GetAllEvents(_userid);
            return new JsonResult(events);
        }

        public JsonResult GetByModerator()
        {
            ICollection<Event> events = _repo.GetAllModeratedEvents(_userid);
            return new JsonResult(events);
        }

        public JsonResult GetUpcomming()
        {
            ICollection<Event> events = _repo.GetAllUpcommingEvents();
            return new JsonResult(events);
        }

        public JsonResult Completed()
        {
            ICollection<Event> events = _repo.GetAllCompletedEvents(_userid);
            return new JsonResult(events);
        }
    }
}
