using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.DTO;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly TARge21ShopContext _context;
        public SpaceshipsServices(TARge21ShopContext context)
        {
            _context = context;
        }
        public async Task<Spaceship> Add(SpaceshipDTO dto)
        {
            var domain = new Spaceship()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                ShipType = dto.ShipType,
                CrewCount = dto.CrewCount,
                PassangerCount = dto.PassangerCount,
                Cargo = dto.Cargo,
                FullTripCount = dto.FullTripCount,
                MaidenLaunch = dto.MaidenLaunch,
                LastMaintenance = dto.LastMaintenance,
                EnginePower = dto.EnginePower,
                BuildDate = dto.BuildDate,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            await _context.Spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
        public async Task<Spaceship> Update(SpaceshipDTO dto)
        {
            var domain = new Spaceship()
            {
                Id = dto.Id,
                Name = dto.Name,
                ShipType = dto.ShipType,
                CrewCount = dto.CrewCount,
                PassangerCount = dto.PassangerCount,
                Cargo = dto.Cargo,
                FullTripCount = dto.FullTripCount,
                MaidenLaunch = dto.MaidenLaunch,
                LastMaintenance = dto.LastMaintenance,
                EnginePower = dto.EnginePower,
                BuildDate = dto.BuildDate,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };
            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Spaceship> GetUpdate(Guid Id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == Id);

            return result;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships.FirstOrDefaultAsync(x => x.Id == id);
            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();
            return spaceshipId;
        }

        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

    }
}
