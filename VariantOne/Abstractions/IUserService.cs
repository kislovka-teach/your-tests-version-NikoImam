using VariantOne.Entities;

namespace VariantOne.Abstractions
{
    public interface IUserService
    {
        public Task<IResult> Authorize(User user, HttpContext context);

        public Task<bool> Registrate(User user);
    }
}
