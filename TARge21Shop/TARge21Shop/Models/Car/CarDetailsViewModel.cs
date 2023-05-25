using Microsoft.AspNetCore.Mvc;

namespace TARge21Shop.Models.Car
{
    public class CarDetailsViewModel : Controller
    {
        public Guid? Id { get; set; }
        public string Make { get; set; } //ex: tesla
        public string ModelName { get; set; } //ex: focus
        public int EnginePower { get; set; } //in kw
        public string EngineType { get; set; } //ex: V8, electric
        public int OneTankDistance { get; set; } //kmage on one full tank/charge
        public int SeatCount { get; set; } //how many seats in vehidle
        public string BodyType { get; set; } //ex: hatchback
        public int Price { get; set; }
        public int CarAge { get; set; } // age of the vehicle, if 0, then new
        public string LicensePlate { get; set; } // license plate number for this car
        public DateTime LastMaintenance { get; set; } // when car was last maintained
        public DateTime LastInspection { get; set; } //when it was last inspected, not maintained
        public DateTime BuiltDate { get; set; } //when vehicle was assembled

        // only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        //public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();
    }
}
