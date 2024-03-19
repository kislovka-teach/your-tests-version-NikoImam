namespace VariantTwo.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public string? Topic { get; set; }
        public string? Text { get; set; }
        public DateOnly PublishDate { get; set; }
        public int Rating { get; set; }
        public int AuthorId { get; set; }
        public User? Author { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
