namespace TARge21Shop.Models.Spaceship
{
    public class SpaceshipDetailsViewModel
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
            public DateTime CreatedAt { get; set; }
            public DateTime ModifiedAt { get; set; }

    }
}
