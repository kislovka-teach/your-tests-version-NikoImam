using VariantTwo.Entities;

namespace VariantTwo.Models.ResultModels
{
    public class ArticleFull
    {
        public string? Title { get; set; }
        public Car? Car { get; set; }
        public string? Topic { get; set; }
        public string? Text { get; set; }
        public DateOnly PublishDate { get; set; }
        public int Rating { get; set; }
        public User? Author { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
