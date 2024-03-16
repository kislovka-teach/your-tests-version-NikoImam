using Microsoft.AspNetCore.Authorization;
using VariantTwo.Models.RequestModels;

namespace VariantTwo.Abstractions
{
    public interface IArticleService
    {
        [Authorize]
        public Task AddComment(Comment comment);

        [Authorize]
        public Task Vote(int id);
    }
}
