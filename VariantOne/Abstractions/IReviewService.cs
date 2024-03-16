namespace VariantOne.Abstractions
{
    public interface IReviewService
    {
        public Task AddReview(Models.RequestModels.Review review);
    }
}
