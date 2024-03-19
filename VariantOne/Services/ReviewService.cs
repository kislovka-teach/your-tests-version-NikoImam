using AutoMapper;
using VariantOne.Abstractions;
using VariantOne.DbContexts;
using VariantOne.Models.RequestModels;

namespace VariantOne.Services
{
    public class ReviewService : IReviewService
    {
        IMapper _mapper;
        ApplicationContext _applicationContext;

        public ReviewService(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
        }

        public async Task AddReview(Review review)
        {
            await _applicationContext.Reviews.AddAsync(_mapper.Map<Entities.Review>(review));
        }
    }
}
