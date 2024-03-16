namespace VariantOne.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
