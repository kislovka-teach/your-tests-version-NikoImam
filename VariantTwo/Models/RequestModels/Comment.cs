namespace VariantTwo.Models.RequestModels
{
    public class Comment
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string? Text { get; set; }
    }
}
