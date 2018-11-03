using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorshiaExam.Models;

namespace TorshiaExam.ViewModels.Tasks
{
    public class TaskDetailsInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public virtual ICollection<TaskSector> AffectedSectors { get; set; } = new List<TaskSector>();

        public int Level
        {
            get { return this.AffectedSectors.Count; }
        }

        public IList<Sector> Sectors { get; set; } = new List<Sector>();

        public void GetSectors(ICollection<TaskSector> afSectors)
        {
            foreach (var sector in afSectors)
            {
                var strinos = sector.ToString().TrimEnd(',',' ');
            }
        }

    }
}
