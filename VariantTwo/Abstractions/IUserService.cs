using Microsoft.AspNetCore.Authorization;
using VariantTwo.Entities;

namespace VariantTwo.Abstractions
{
    public interface IUserService
    {
        public Task<IResult> Authorize(User user, HttpContext context);

        public Task<bool> Registrate(User user);

        public Task<int> GetUserId(HttpContext context);
    }
}
