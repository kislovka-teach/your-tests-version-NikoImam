using System.Drawing;

namespace VariantTwo.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public CarModel? CarModel { get; set; }
        public string? Color { get; set; }
        public int Year { get; set; }
        public PowerPlant PowerPlant { get; set; }
        public int HorsePowers { get; set; }
        public int OwnerId { get; set; }
        public User? Owner { get; set; }
    }
}
