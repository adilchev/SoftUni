using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventuresWebApp.Services;
using EventuresWebApp.Services.Implementations;
using EventuresWebApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventuresWebApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(EventCreateModel model)
        {
            if (ModelState.IsValid)
            {
                this.eventService.Create(model);
               return Redirect("/");
            }
            return this.View(model);
        }

        [Authorize]
        public IActionResult All()
        {
           var events= this.eventService.All();
            return this.View(events);
        }
    }
}