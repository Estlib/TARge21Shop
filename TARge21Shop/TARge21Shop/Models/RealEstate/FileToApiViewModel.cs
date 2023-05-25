using Microsoft.AspNetCore.Mvc;

namespace TARge21Shop.Models.RealEstate
{
    public class FileToApiViewModel : Controller
    {
        public Guid ImageId { get; set; }
        public string FilePath { get; set; }
        public Guid RealEstateId { get; set; }
    }
}
