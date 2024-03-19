using VariantOne.Entities;

namespace VariantOne.Models.RequestModels
{
    public class Order
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }
        public Status Status { get; set; } = Status.Preparing;
    }
}
