using System;
using System.Collections.Generic;
using System.Text;

namespace TorshiaExam.ViewModels.Reports
{
    public class ReportDetailsInputModel
    {
        public int Id { get; set; }

        public string Task { get; set; }

        public int Level { get; set; }

        public string Status { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime ReportedOn { get; set; } = DateTime.UtcNow;

        public string Reporter { get; set; }

        public string Participants { get; set; }

        public string AffectedSectors { get; set; }

        public string Description { get; set; }
    }
}
