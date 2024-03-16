using AutoMapper;

namespace VariantOne.Configurations.Mapping
{
    public class TeaMapperProfile : Profile
    {
        public TeaMapperProfile()
        {
            CreateMap<Entities.Tea, Models.RequestModels.Tea>().ReverseMap();
        }
    }
}
