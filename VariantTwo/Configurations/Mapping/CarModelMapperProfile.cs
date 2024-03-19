using AutoMapper;

namespace VariantTwo.Configurations.Mapping
{
    public class CarModelMapperProfile : Profile
    {
        public CarModelMapperProfile()
        {
            CreateMap<Entities.CarModel, Models.RequestModels.CarModel>().ReverseMap();
        }
    }
}
