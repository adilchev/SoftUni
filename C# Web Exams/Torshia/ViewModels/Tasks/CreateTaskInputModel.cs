using System;
using System.Collections.Generic;
using System.Text;
using TorshiaExam.Models;

namespace TorshiaExam.ViewModels.Tasks
{
    public class CreateTaskInputModel
    {
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

       // public bool IsReported { get; set; } = false;

        public string Description { get; set; }

        public string Participants { get; set; }

        public virtual ICollection<TaskSector> AffectedSectors { get; set; } = new List<TaskSector>();

        private Sector financeSector;
        public Sector FinanceSector
        {
            get { return this.financeSector; }
            set { financeSector = Sector.Finances; }
        }
        private Sector marketingSector;
        public Sector MarketingSector
        {
            get { return this.marketingSector; }
            set { marketingSector = Sector.Marketing; }
        }
        private Sector managementSector;
        public Sector ManagementSector
        {
            get { return this.managementSector; }
            set { managementSector = Sector.Management; }
        }
        private Sector customerSector;
        public Sector CustomerSector
        {
            get { return this.customerSector; }
            set { customerSector = Sector.Customers; }
        }

        private Sector internalSector;
        public Sector InternalSector
        {
            get { return this.internalSector; }
            set { internalSector = Sector.Internal; }
        }
     

    }
}
