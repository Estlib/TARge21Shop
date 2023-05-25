using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21Shop.Core.Dto
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string Make { get; set; }
        public string ModelName { get; set; }
        public int EnginePower { get; set; }
        public string EngineType { get; set; }
        public int OneTankDistance { get; set; }
        public int SeatCount { get; set; }
        public string BodyType { get; set; }
        public int Price { get; set; }
        public int CarAge { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LastMaintenance { get; set; }
        public DateTime LastInspection { get; set; }
        public DateTime BuiltDate { get; set; }

        // only in database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
    }
}
