using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Data;
using TARge21Shop.Models.Spaceship;


namespace TARge21Shop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARge21ShopContext _context;

        public SpaceshipsController(TARge21ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShipType = x.ShipType,
                    PassangerCount = x.PassangerCount,
                    CrewCount = x.CrewCount,
                    Cargo = x.Cargo,
                    EnginePower = x.EnginePower
                });

            return View(result);
        }

        public IActionResult Add()
        {
            return View("Edit");
        }
    }
}
