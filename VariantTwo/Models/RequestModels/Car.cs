using VariantTwo.Entities;

namespace VariantTwo.Models.RequestModels
{
    public class Car
    {
        public int CarModelId { get; set; }
        public int OwnerId { get; set; }
        public string? Color { get; set; }
        public int Year { get; set; }
        public PowerPlant PowerPlant { get; set; }
        public int HorsePowers { get; set; }
    }
}
