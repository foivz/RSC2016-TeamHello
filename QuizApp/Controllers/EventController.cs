using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Database;
using QuizApp.Database.Model;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizApp.Controllers.Requests
{
    [Route("api/events")]
    public class EventController : Controller
    {
        QuizDbRepo _repo;
        public EventController(QuizDbRepo repo)
        {
            _repo = repo;
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

        [HttpGet("getByMod/{id}")]
        public JsonResult GetByModerator(int id)
        {
            ICollection<Event> events = _repo.GetEventsByModerator(id);
            return new JsonResult(events);
        }

        [HttpGet("getFutureByMod/{id}")]
        public JsonResult GetByModeratorUpcomming(int id)
        {
            ICollection<Event> events = _repo.GetAllUpcommingModeratedEvents(id);
            return new JsonResult(events);
        }

        [HttpGet("getPastByMod/{id}")]
        public JsonResult GetByModeratorComplete(int id)
        {
            ICollection<Event> events = _repo.GetAllCompletedEventsByMod(id);
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

        [HttpGet("getAllByParticipant/{id}")]
        public JsonResult GetAllByParticipant(int id)
        {
            ICollection<Event> events = _repo.GetAllUserEvents(id);
            return new JsonResult(events);
        }

        [HttpGet("getAllByUser/{id}")]
        public JsonResult GetAllByUser(int id)
        {
            List<Event> events = _repo.GetAllUserEvents(id).ToList();
            events.AddRange(_repo.GetAllModeratedEvents(id));
            return new JsonResult(events);
        }

        [HttpGet("getallusercompleted/{id}")]
        public JsonResult GetAllUserCompleted(int id)
        {
            ICollection<Event> events = _repo.GetAllUserCompletedEvents(id);
            return new JsonResult(events);
        }

        [HttpGet("getAllFuture/{id}")]
        public JsonResult GetAllUserUpcomming(int id)
        {
            ICollection<Event> events = _repo.GetAllUserUpcommingEvents(id);
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
