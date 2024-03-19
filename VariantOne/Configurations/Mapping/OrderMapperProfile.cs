using AutoMapper;

namespace VariantOne.Configurations.Mapping
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Entities.Order, Models.RequestModels.Order>().ReverseMap();
        }
    }
}
