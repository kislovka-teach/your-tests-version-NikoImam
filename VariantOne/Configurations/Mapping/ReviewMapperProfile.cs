using AutoMapper;

namespace VariantOne.Configurations.Mapping
{
    public class ReviewMapperProfile : Profile
    {
        public ReviewMapperProfile()
        {
            CreateMap<Entities.Review, Models.RequestModels.Review>().ReverseMap();
        }
    }
}
