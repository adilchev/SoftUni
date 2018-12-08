using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using EventuresWebApp.Data.Migrations;
using EventuresWebApp.Models;
using EventuresWebApp.Services.Models;

namespace EventuresWebApp.Services
{
    public interface IEventService
    {
        void Create(EventCreateModel model);

        IList<AllEvents> All();
    }
}
