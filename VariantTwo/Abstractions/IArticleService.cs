using Microsoft.AspNetCore.Authorization;
using VariantTwo.Models.RequestModels;

namespace VariantTwo.Abstractions
{
    public interface IArticleService
    {
        [Authorize]
        public Task AddComment(Comment comment);

        [Authorize]
        public Task<IResult> Vote(int id, HttpContext context);
    }
}
