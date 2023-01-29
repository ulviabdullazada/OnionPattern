using TheCheckpoint.Domain.Entities.Common;

namespace TheCheckpoint.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int StockCount { get; set; }
        public byte Discount { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<ProductImageFile>? ProductImageFiles { get; set; }
    }
}
