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
        IUserService _userService;
        public ArticleService(IMapper mapper, ApplicationContext applicationContext, IUserService userService)
        {
            _mapper = mapper;
            _applicationContext = applicationContext;
            _userService = userService;
        }

        public async Task AddComment(Comment comment)
        {
            await _applicationContext.Comments.AddAsync(_mapper.Map<Entities.Comment>(comment));
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<IResult> Vote(int id, HttpContext context)
        {
            var i = await _userService.GetUserId(context);
            var article = await _applicationContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (article!.AuthorId == i) return Results.BadRequest();
            article!.Rating++;
            await _applicationContext.SaveChangesAsync();
            return Results.Ok();
        }
    }
}
