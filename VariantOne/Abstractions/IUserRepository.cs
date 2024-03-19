using VariantOne.Entities;

namespace VariantOne.Abstractions
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(User user);

        public Task<User?> GetUser(string? username);
    }
}
