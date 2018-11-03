using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TorshiaExam.Models;

namespace TorshiaExam.ViewModels.Home
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

      //  public bool IsReported { get; set; }

        public int Level
        {
            get { return this.AffectedSectors.Count; }
        }

        public virtual ICollection<TaskSector> AffectedSectors { get; set; } = new List<TaskSector>();

        
    }
}
