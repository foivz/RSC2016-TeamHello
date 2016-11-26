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
    [Route("api/events")]
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
        public int Create([FromBody]Event _event)
        {
            return _repo.CreateEvent(_event);
        }

        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _repo.GetEvent(id);
        }

        [HttpPut("edit")]
        public int Edit([FromBody]Event _event)
        {
            return _repo.Edit(_event);
        }

        [HttpGet("getAll")]
        public JsonResult GetAll()
        {
            ICollection<Event> events = _repo.GetAllEvents();
            return new JsonResult(events);
        }

        [HttpGet("getByMod")]
        public JsonResult GetByModerator()
        {
            ICollection<Event> events = _repo.GetEventsByModerator(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getFutureByMod")]
        public JsonResult GetByModeratorUpcomming()
        {
            ICollection<Event> events = _repo.GetAllUpcommingModeratedEvents(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getPastByMod")]
        public JsonResult GetByModeratorComplete()
        {
            ICollection<Event> events = _repo.GetAllCompletedEventsByMod(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getFutureByUser")]
        public JsonResult GetAllUpcomming()
        {
            ICollection<Event> events = _repo.GetAllUpcommingEvents();
            return new JsonResult(events);
        }

        [HttpGet("getAllCompleted")]
        public JsonResult GetAllCompleted()
        {
            ICollection<Event> events = _repo.GetAllCompletedEvents();
            return new JsonResult(events);
        }

        [HttpGet("getAllByParticipant")]
        public JsonResult GetAllByParticipant()
        {
            ICollection<Event> events = _repo.GetAllUserEvents(_userid);
            return new JsonResult(events);
        }

        [HttpGet("getAllByUser")]
        public JsonResult GetAllByUser()
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

        [HttpGet("getAllFuture")]
        public JsonResult GetAllUserUpcomming()
        {
            ICollection<Event> events = _repo.GetAllUserUpcommingEvents(_userid);
            return new JsonResult(events);
        }

        [AllowAnonymous]
        [HttpGet("getAllActive")]
        public JsonResult GetAllActive()
        {
            ICollection<Event> events = _repo.GetAllActiveEvents();
            return new JsonResult(events);
        }
    }
}
