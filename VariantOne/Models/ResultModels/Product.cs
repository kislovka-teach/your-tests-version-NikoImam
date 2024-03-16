using VariantOne.Entities;

namespace VariantOne.Models.ResultModels
{
    public class Product
    {
        public Tea? Tea { get; set; }
        public PackagingType PackagingType { get; set; }
        public int Volume { get; set; } = 0;
        public int Price { get; set; }
    }
}
