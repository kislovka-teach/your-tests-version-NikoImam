using Microsoft.AspNetCore.Authorization;
using VariantTwo.Models.RequestModels;
using VariantTwo.Models.ResultModels;

namespace VariantTwo.Abstractions
{
    public interface IArticleRepository
    {
        [Authorize]
        public Task AddArticle(Article article);

        public Task<ArticleFull> GetArticle(int id);

        public Task<List<ArticleLite>> GetAllArticles();

        public Task<List<ArticleLite>> GetFirstTopArticles(int count);
    }
}
