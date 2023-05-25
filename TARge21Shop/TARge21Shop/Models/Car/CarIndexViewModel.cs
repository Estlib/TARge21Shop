using Microsoft.AspNetCore.Mvc;

namespace TARge21Shop.Models.Car
{
    public class CarIndexViewModel : Controller
    {
        public Guid? Id { get; set; }
        public string Make { get; set; } //ex: tesla
        public string ModelName { get; set; } //ex: focus
        public int EnginePower { get; set; } //in kw
        public int SeatCount { get; set; } //how many seats in vehidle
        public int Price { get; set; }

    }
}
