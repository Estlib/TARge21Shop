using Microsoft.AspNetCore.Mvc;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.DTO;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Spaceship;


namespace TARge21Shop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly ISpaceshipsServices _spaceshipsServices;

        public SpaceshipsController(TARge21ShopContext context, ISpaceshipsServices spaceshipsServices)
        {
            _context = context;
            _spaceshipsServices = spaceshipsServices;
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

        [HttpGet]
        public IActionResult Add()
        {
            SpaceshipEditViewModel spaceship = new SpaceshipEditViewModel();

            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipEditViewModel vm)
        {
            var dto = new SpaceshipDTO()
            {
                Id = vm.Id,
                Name = vm.Name,
                ShipType = vm.ShipType,
                CrewCount = vm.CrewCount,
                PassangerCount = vm.PassangerCount,
                Cargo = vm.Cargo,
                FullTripCount = vm.FullTripCount,
                MaidenLaunch = vm.MaidenLaunch,
                LastMaintenance = vm.LastMaintenance,
                EnginePower = vm.EnginePower,
                BuildDate = vm.BuildDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt

            };

            var result = await _spaceshipsServices.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var spaceship = await _spaceshipsServices.GetUpdate(Id);

            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipEditViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                ShipType = spaceship.ShipType,
                CrewCount = spaceship.CrewCount,
                PassangerCount = spaceship.PassangerCount,
                Cargo = spaceship.Cargo,
                FullTripCount = spaceship.FullTripCount,
                MaidenLaunch = spaceship.MaidenLaunch,
                LastMaintenance = spaceship.LastMaintenance,
                EnginePower = spaceship.EnginePower,
                BuildDate = spaceship.BuildDate,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt

            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipEditViewModel vm)
        {
            var dto = new SpaceshipDTO()
            {
                Id = vm.Id,
                Name = vm.Name,
                ShipType = vm.ShipType,
                CrewCount = vm.CrewCount,
                PassangerCount = vm.PassangerCount,
                Cargo = vm.Cargo,
                FullTripCount = vm.FullTripCount,
                MaidenLaunch = vm.MaidenLaunch,
                LastMaintenance = vm.LastMaintenance,
                EnginePower = vm.EnginePower,
                BuildDate = vm.BuildDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _spaceshipsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var spaceshipId = await _spaceshipsServices.Delete(id);
            if (spaceshipId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            var spaceship = await _spaceshipsServices.GetAsync(Id);

            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipDetailsViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                ShipType = spaceship.ShipType,
                CrewCount = spaceship.CrewCount,
                PassangerCount = spaceship.PassangerCount,
                Cargo = spaceship.Cargo,
                FullTripCount = spaceship.FullTripCount,
                MaidenLaunch = spaceship.MaidenLaunch,
                LastMaintenance = spaceship.LastMaintenance,
                EnginePower = spaceship.EnginePower,
                BuildDate = spaceship.BuildDate,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt

            };

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var spaceship = await _spaceshipsServices.GetAsync(Id);

            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipDeleteViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                ShipType = spaceship.ShipType,
                CrewCount = spaceship.CrewCount,
                PassangerCount = spaceship.PassangerCount,
                Cargo = spaceship.Cargo,
                FullTripCount = spaceship.FullTripCount,
                MaidenLaunch = spaceship.MaidenLaunch,
                LastMaintenance = spaceship.LastMaintenance,
                EnginePower = spaceship.EnginePower,
                BuildDate = spaceship.BuildDate,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt

            };

            return View(vm);
        }
    }
}
