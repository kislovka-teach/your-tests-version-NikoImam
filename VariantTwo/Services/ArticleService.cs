using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using VariantTwo.Abstractions;
using VariantTwo.DbContexts;
using VariantTwo.Models.RequestModels;

namespace VariantTwo.Services
{
    public class ArticleService : IArticleService
    {
        IMapper _mapper;
        ApplicationContext _applicationContext;
        public ArticleService(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
        }

        public async Task AddComment(Comment comment)
        {
            await _applicationContext.Comments.AddAsync(_mapper.Map<Entities.Comment>(comment));
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Vote(int id)
        {
            var article = await _applicationContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
            article!.Rating++;
            await _applicationContext.SaveChangesAsync();
        }
    }
}
