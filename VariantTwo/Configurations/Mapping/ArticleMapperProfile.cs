using AutoMapper;

namespace VariantTwo.Configurations.Mapping
{
    public class ArticleMapperProfile : Profile
    {
        public ArticleMapperProfile()
        {
            CreateMap<Entities.Article, Models.RequestModels.Article>().ReverseMap();
            CreateMap<Entities.Article, Models.ResultModels.ArticleLite>().ReverseMap();
            CreateMap<Entities.Article, Models.ResultModels.ArticleFull>().ReverseMap();
        }
    }
}
