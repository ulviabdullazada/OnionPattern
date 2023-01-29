using Microsoft.AspNetCore.Http;
using TheCheckpoint.Domain.Entities;

namespace TheCheckpoint.Application.ViewModels
{
    public class ProductCreateVM
    {
        public string Name{ get; set; }
        public float Price { get; set; }
        public int StockCount { get; set; }
        public byte Discount { get; set; }
        public IFormFile CoverImage { get; set; }
        public ICollection<IFormFile> Images { get; set; }
    }
}
