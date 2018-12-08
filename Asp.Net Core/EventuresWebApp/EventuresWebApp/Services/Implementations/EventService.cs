using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventuresWebApp.Data;
using EventuresWebApp.Models;
using EventuresWebApp.Services.Models;

namespace EventuresWebApp.Services.Implementations
{
    public class EventService:IEventService
    {
        private readonly ApplicationDbContext db;

        public EventService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(EventCreateModel model)
        {
            var eventModel = new Event
            {
                End = model.End,
                Name = model.Name,
                PricePerTicket = model.PricePerTicket,
                Place = model.Place,
                Start = model.Start,
                TotalTickets = model.TotalTickets
            };

            this.db.Events.Add(eventModel);
            this.db.SaveChanges();
        }

        public IList<AllEvents> All()
        {
          var allEvents=  this.db.Events.Select(x => new AllEvents()
            {
                End = x.End,
                Start = x.Start,
                Name = x.Name,
                Place = x.Place
            }).ToList();

            return allEvents;
        }
    }
}
