using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VariantTwo.Abstractions;
using VariantTwo.DbContexts;
using VariantTwo.Models.RequestModels;
using VariantTwo.Models.ResultModels;

namespace VariantTwo.Services
{
    public class ArticleRepository : IArticleRepository
    {
        IMapper _mapper;
        ApplicationContext _applicationContext;
        public ArticleRepository(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
        }
        public async Task AddArticle(Article article)
        {
            await _applicationContext.Articles.AddAsync(_mapper.Map<Entities.Article>(article));
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<List<ArticleLite>> GetAllArticles()
        {
            return _mapper.Map<List<ArticleLite>>(await  _applicationContext.Articles.ToListAsync());
        }

        public async Task<ArticleFull> GetArticle(int id)
        {
            return _mapper.Map<ArticleFull>(await _applicationContext.Articles.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<List<ArticleLite>> GetFirstTopArticles(int count)
        {
            return _mapper.Map<List<ArticleLite>>(await _applicationContext.Articles.OrderBy(x => x.Rating).Take(count).ToListAsync());
        }
    }
}
