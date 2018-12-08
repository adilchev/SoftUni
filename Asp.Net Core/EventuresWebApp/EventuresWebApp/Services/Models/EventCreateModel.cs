using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventuresWebApp.Services.Models
{
    public class EventCreateModel
    {
        public string Name { get; set; }

        public string Place { get; set; }
      
        public DateTime Start { get; set; }
       
        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public decimal PricePerTicket { get; set; }
    }
}
