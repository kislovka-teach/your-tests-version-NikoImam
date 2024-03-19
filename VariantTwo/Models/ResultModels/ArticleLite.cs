using VariantTwo.Entities;

namespace VariantTwo.Models.ResultModels
{
    public class ArticleLite
    {
        public string? Title { get; set; }
        public Car? Car { get; set; }
        public string? Topic { get; set; }
        public string? Text { get; set; }
        public User? Author { get; set; }
    }
}
