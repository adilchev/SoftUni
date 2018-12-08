using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventuresWebApp.Models
{
    public class Event
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(10)]
        [RegularExpression(".+")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(".+")]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        public decimal PricePerTicket { get; set; }
    }
}
