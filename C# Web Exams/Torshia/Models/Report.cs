using System;
using System.Collections.Generic;
using System.Text;
using TorshiaExam.Models.Enums;

namespace TorshiaExam.Models
{
    public class Report
    {
        public int Id { get; set; }

        public ReportStatus Status { get; set; }

        public DateTime ReportedOn { get; set; } = DateTime.UtcNow;

        public int TaskId { get; set; }

        public virtual Task Task{ get; set; }

        public int ReporterId { get; set; }

        public virtual User  Reporter{ get; set; }
    }
}
