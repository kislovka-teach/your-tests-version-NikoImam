using VariantOne.Entities;

namespace VariantOne.Models.RequestModels
{
    public class Product
    {
        public int TeaId { get; set; }
        public PackagingType PackagingType { get; set; }
        public int Volume { get; set; } = 0;
        public string? Manufacturer { get; set; }
        public int QuantityInStock { get; set; }
        public int Price { get; set; }
    }
}
