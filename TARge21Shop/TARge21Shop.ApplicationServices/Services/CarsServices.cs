using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARge21ShopContext _context;
        private readonly IFilesServices _files;

        public CarsServices
            (
                TARge21ShopContext context,
                IFilesServices files
            )
        {
            _context = context;
            _files = files;
        }


        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();
            //FileCarToDatabase file = new FileCarToDatabase();

            car.Id = Guid.NewGuid();
            car.Make = dto.Make;
            car.ModelName = dto.ModelName;
            car.EnginePower = dto.EnginePower;
            car.EngineType = dto.EngineType;
            car.OneTankDistance = dto.OneTankDistance;
            car.SeatCount = dto.SeatCount;
            car.BodyType = dto.BodyType;
            car.Price = dto.Price;
            car.CarAge = dto.CarAge;
            car.LicensePlate = dto.LicensePlate;
            car.LastMaintenance = dto.LastMaintenance;
            car.LastInspection = dto.LastInspection;
            car.BuiltDate = dto.BuiltDate;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            //if (dto.Files != null)
            //{
            //    _files.UploadFilesToDatabase(dto, car);
            //}


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }


        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car()
            {
                Id = dto.Id,
                Make = dto.Make,
                ModelName = dto.ModelName,
                EnginePower = dto.EnginePower,
                EngineType = dto.EngineType,
                OneTankDistance = dto.OneTankDistance,
                SeatCount = dto.SeatCount,
                BodyType = dto.BodyType,
                Price = dto.Price,
                CarAge = dto.CarAge,
                LicensePlate = dto.LicensePlate,
                LastMaintenance = dto.LastMaintenance,
                LastInspection = dto.LastInspection,
                BuiltDate = dto.BuiltDate,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };

            //if (dto.Files != null)
            //{
            //    _files.UploadFilesToDatabase(dto, domain);
            //}

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }


        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            //var images = await _context.FileCarToDatabases
            //    .Where(x => x.CarId == id)
            //    .Select(y => new FileCarToDatabaseDto
            //    {
            //        Id = y.Id,
            //        ImageTitle = y.ImageTitle,
            //        CarId = y.CarId,
            //    })
            //    .ToArrayAsync();

            //await _files.RemoveImagesFromDatabase(images);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
