using AutoMapper;

namespace VariantTwo.Configurations.Mapping
{
    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<Entities.Comment, Models.RequestModels.Comment>().ReverseMap();
        }
    }
}
