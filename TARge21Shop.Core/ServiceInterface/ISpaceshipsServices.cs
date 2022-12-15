using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain.Spaceship;
using TARge21Shop.Core.DTO;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Add(SpaceshipDTO dto);
        Task<Spaceship> GetUpdate(Guid Id);
        Task<Spaceship> Update(SpaceshipDTO dto);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> GetAsync(Guid id);
    }
}
