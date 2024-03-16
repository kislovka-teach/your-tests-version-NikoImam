using AutoMapper;

namespace VariantOne.Configurations.Mapping
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Entities.Product, Models.RequestModels.Product>().ReverseMap();
            CreateMap<Entities.Product, Models.ResultModels.Product>().ReverseMap();
        }
    }
}
