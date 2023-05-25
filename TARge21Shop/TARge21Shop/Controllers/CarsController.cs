using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Car;

namespace TARge21Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly ICarsServices _carsServices;
        private readonly IFilesServices _filesServices;

        public CarsController
        (
        TARge21ShopContext context,
                ICarsServices carsServices,
                IFilesServices filesServices
            )
        {
            _context = context;
            _carsServices = carsServices;
            _filesServices = filesServices;
        }


        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Make = x.Make,
                    ModelName = x.ModelName,
                    EnginePower = x.EnginePower,
                    SeatCount = x.SeatCount
                });

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel car = new CarCreateUpdateViewModel();

            return View("CreateUpdate", car);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                ModelName = vm.ModelName,
                EnginePower = vm.EnginePower,
                EngineType = vm.EngineType,
                OneTankDistance = vm.OneTankDistance,
                SeatCount = vm.SeatCount,
                BodyType = vm.BodyType,
                Price = vm.Price,
                CarAge = vm.CarAge,
                LicensePlate = vm.LicensePlate,
                LastMaintenance = vm.LastMaintenance,
                LastInspection = vm.LastInspection,
                BuiltDate = vm.BuiltDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                //Files = vm.Files,
                //Image = vm.Image.Select(x => new FileToDatabaseDto
                //{
                //    Id = x.ImageId,
                //    ImageData = x.ImageData,
                //    ImageTitle = x.ImageTitle,
                //    CarId = x.CarId,
                //}).ToArray()
            };

            var result = await _carsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            //var photos = await _context.FileToDatabases
            //    .Where(x => x.CarId == id)
            //    .Select(y => new ImageViewModel
            //    {
            //        carId = y.Id,
            //        ImageId = y.Id,
            //        ImageData = y.ImageData,
            //        ImageTitle = y.ImageTitle,
            //        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
            //    }).ToArrayAsync();

            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.ModelName = car.ModelName;
            vm.EnginePower = car.EnginePower;
            vm.EngineType = car.EngineType;
            vm.OneTankDistance = car.OneTankDistance;
            vm.SeatCount = car.SeatCount;
            vm.BodyType = car.BodyType;
            vm.Price = car.Price;
            vm.CarAge = car.CarAge;
            vm.LicensePlate = car.LicensePlate;
            vm.LastMaintenance = car.LastMaintenance;
            vm.LastInspection = car.LastInspection;
            vm.BuiltDate = car.BuiltDate;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            //vm.Image.AddRange(photos);

            return View("CreateUpdate", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                ModelName = vm.ModelName,
                EnginePower = vm.EnginePower,
                EngineType = vm.EngineType,
                OneTankDistance = vm.OneTankDistance,
                SeatCount = vm.SeatCount,
                BodyType = vm.BodyType,
                Price = vm.Price,
                CarAge = vm.CarAge,
                LicensePlate = vm.LicensePlate,
                LastMaintenance = vm.LastMaintenance,
                LastInspection = vm.LastInspection,
                BuiltDate = vm.BuiltDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                //Files = vm.Files,
                //Image = vm.Image.Select(x => new FileToDatabaseDto
                //{
                //    Id = x.ImageId,
                //    ImageData = x.ImageData,
                //    ImageTitle = x.ImageTitle,
                //    carId = x.carId,
                //}).ToArray()
            };

            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            //var photos = await _context.FileToDatabases
            //    .Where(x => x.carId == id)
            //    .Select(y => new ImageViewModel
            //    {
            //        carId = y.Id,
            //        ImageId = y.Id,
            //        ImageData = y.ImageData,
            //        ImageTitle = y.ImageTitle,
            //        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
            //    }).ToArrayAsync();

            var vm = new CarDetailsViewModel();

            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.ModelName = car.ModelName;
            vm.EnginePower = car.EnginePower;
            vm.EngineType = car.EngineType;
            vm.OneTankDistance = car.OneTankDistance;
            vm.SeatCount = car.SeatCount;
            vm.BodyType = car.BodyType;
            vm.Price = car.Price;
            vm.CarAge = car.CarAge;
            vm.LicensePlate = car.LicensePlate;
            vm.LastMaintenance = car.LastMaintenance;
            vm.LastInspection = car.LastInspection;
            vm.BuiltDate = car.BuiltDate;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            //vm.Image.AddRange(photos);

            return View(vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            //var photos = await _context.FileToDatabases
            //    .Where(x => x.carId == id)
            //    .Select(y => new ImageViewModel
            //    {
            //        carId = y.Id,
            //        ImageId = y.Id,
            //        ImageData = y.ImageData,
            //        ImageTitle = y.ImageTitle,
            //        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
            //    }).ToArrayAsync();

            var vm = new CarDeleteViewModel();

            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.ModelName = car.ModelName;
            vm.EnginePower = car.EnginePower;
            vm.EngineType = car.EngineType;
            vm.OneTankDistance = car.OneTankDistance;
            vm.SeatCount = car.SeatCount;
            vm.BodyType = car.BodyType;
            vm.Price = car.Price;
            vm.CarAge = car.CarAge;
            vm.LicensePlate = car.LicensePlate;
            vm.LastMaintenance = car.LastMaintenance;
            vm.LastInspection = car.LastInspection;
            vm.BuiltDate = car.BuiltDate;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            //vm.Image.AddRange(photos);


            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);

            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ImageViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId
            };

            var image = await _filesServices.RemoveImage(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
