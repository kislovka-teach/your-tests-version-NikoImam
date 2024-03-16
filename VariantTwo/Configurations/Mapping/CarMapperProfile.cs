using AutoMapper;

namespace VariantTwo.Configurations.Mapping
{
    public class CarMapperProfile : Profile
    {
        public CarMapperProfile()
        {
            CreateMap<Entities.Car, Models.RequestModels.Car>().ReverseMap();
        }
    }
}
