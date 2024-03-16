namespace VariantTwo.Models.RequestModels
{
    public class Article
    {
        public string? Title { get; set; }
        public int CarId { get; set; }
        public int AuthorId { get; set; }
        public string? Topic { get; set; }
        public string? Text { get; set; }
        public DateOnly PublishDate { get; set; }
    }
}
