using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventuresWebApp.Models;

namespace EventuresWebApp.Services.Models
{
    public class AllEvents
    {
        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

    }
}
