using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using Xunit;

namespace TARge21Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "TEST-asd";
            spaceship.Type = "TEST-asd";
            spaceship.Crew = 99123;
            spaceship.Passengers = 99123;
            spaceship.CargoWeight = 99123;
            spaceship.FullTripsCount = 99123;
            spaceship.MaintenanceCount = 99123;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            Guid wrongguid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("c614a5cf-5957-406d-9ae0-d08ef781a50b");
            await Svc<ISpaceshipsServices>().GetAsync(guid);
            Assert.NotEqual(wrongguid, guid);
        }
        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();
            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship.Id);

            Assert.Equal(result, addSpaceship);
        }
        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();
            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipsServices>().Create(spaceship);

            var wrongGuid = Guid.NewGuid();

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship2.Id);

            Assert.NotEqual(result.Id.ToString, addSpaceship.Id.ToString);
        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("c614a5cf-5957-406d-9ae0-d08ef781a50b");

            Spaceship spaceship = new Spaceship();

            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("c614a5cf-5957-406d-9ae0-d08ef781a50b");
            spaceship.Name = "Namecececececceec";
            spaceship.Type = "42344344";
            spaceship.Crew = 123;
            spaceship.Passengers = 120003;
            spaceship.CargoWeight = 100023;
            spaceship.FullTripsCount = 102030;
            spaceship.MaintenanceCount = 100000;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.EnginePower = 100000;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            //var spaceshipToUpdate = new SpaceshipDto()
            //{
            //    Name = "updatedname",
            //    EnginePower = 666,
            //};
            await Svc<ISpaceshipsServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
            Assert.DoesNotMatch(spaceship.Name,dto.Name);
            Assert.DoesNotMatch(spaceship.EnginePower.ToString(), dto.EnginePower.ToString());
            Assert.Equal(spaceship.Crew, dto.Crew);
        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData_v2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceship();
            var result = await Svc<ISpaceshipsServices>().Update(update);

            Assert.Equal(update.Id, dto.Id);
            Assert.DoesNotMatch(result.Name, createSpaceship.Name);
            Assert.DoesNotMatch(result.EnginePower.ToString(), createSpaceship.EnginePower.ToString());
            Assert.Equal(result.Crew, createSpaceship.Crew);
            Assert.NotEqual(result.ModifiedAt, createSpaceship.ModifiedAt);
        }
        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenIdIsNull()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto nullupdate = MockNullSpaceship();
            var result = await Svc<ISpaceshipsServices>().Update(nullupdate);

            var nullId = nullupdate.Id;

            Assert.True(result.Id != nullId);
        }
        private SpaceshipDto MockNullSpaceship()
        {
            SpaceshipDto sussySpaceship = new()
            {
                Id = null,
                Name = "noidbecauseitisnull",
                Type = "notypebecauseitisnull",
                Crew = 0,
                Passengers = 0,
                CargoWeight = 0,
                FullTripsCount = 0,
                MaintenanceCount = 0,
                LastMaintenance = DateTime.Now,
                EnginePower = 1000,
                MaidenLaunch = DateTime.Now,
                BuiltDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return sussySpaceship;
        }
        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "Name",
                Type = "asd",
                Crew = 123,
                Passengers = 123,
                CargoWeight = 123,
                FullTripsCount = 123,
                MaintenanceCount = 1000,
                LastMaintenance = DateTime.Now,
                EnginePower = 1000,
                MaidenLaunch = DateTime.Now,
                BuiltDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return spaceship;
        }
        private SpaceshipDto MockUpdateSpaceship()
        {
            SpaceshipDto update = new()
            {
                Name = "Namecececececceec",
                Type = "42344344",
                Crew = 123,
                Passengers = 120003,
                CargoWeight = 100023,
                FullTripsCount = 102030,
                MaintenanceCount = 100000,
                LastMaintenance = DateTime.Now.AddYears(1),
                EnginePower = 100000,
                MaidenLaunch = DateTime.Now.AddYears(1),
                BuiltDate = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };
            return update;
        }
    }
}
