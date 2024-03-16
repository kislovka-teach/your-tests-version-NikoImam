using Microsoft.EntityFrameworkCore;
using VariantOne.Abstractions;
using VariantOne.DbContexts;
using VariantOne.Entities;

namespace VariantOne.Services
{
    public class UserRepository : IUserRepository
    {
        ApplicationContext _applicationContext;
        IHasherService _hasherService;

        public UserRepository(ApplicationContext applicationContext, IHasherService hasherService)
        {
            _applicationContext = applicationContext;
            _hasherService = hasherService;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                user.Salt = _hasherService.GetSalt();
                user.Password = _hasherService.GetHashPassword(user.Password, user.Salt);
                await _applicationContext.Users.AddAsync(user);
                await _applicationContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User?> GetUser(string? username)
        {
            return await _applicationContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
