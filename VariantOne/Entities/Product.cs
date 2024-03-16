namespace VariantOne.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int TeaId { get; set; }
        public Tea? Tea { get; set; }
        public PackagingType PackagingType { get; set; }
        public int Volume { get; set; } = 0;
        public string? Manufacturer { get; set; }
        public int QuantityInStock { get; set; }
        public int Price { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
