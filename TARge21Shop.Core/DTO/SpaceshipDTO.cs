using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21Shop.Core.DTO
{
    public class SpaceshipDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? ShipType { get; set; }
        public int CrewCount { get; set; }
        public int PassangerCount { get; set; }
        public int Cargo { get; set; }
        public int FullTripCount { get; set; }
        public int MaintenanceCount { get; set; }
        public DateTime LastMaintenance { get; set; }
        public DateTime BuildDate { get; set; }
        public int EnginePower { get; set; }
        public DateTime MaidenLaunch { get; set; }
        public DateTime CreatedAt { get; set; } // for db only, date entry created on
        public DateTime ModifiedAt { get; set; } // for db only, date entry last modified on
    }
}
