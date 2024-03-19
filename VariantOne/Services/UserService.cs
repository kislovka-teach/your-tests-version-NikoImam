using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using VariantOne.Abstractions;
using VariantOne.Entities;

namespace VariantOne.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IHasherService _hasherService;
        public UserService(IUserRepository userRepository, IHasherService hasherService)
        {
            _userRepository = userRepository;
            _hasherService = hasherService;
        }

        public async Task<bool> Registrate(User user)
        {
            return await _userRepository.AddUser(user);
        }

        public async Task<IResult> Authorize(User user, HttpContext context)
        {
            var person = await _userRepository.GetUser(user.Username);

            if (person is not null
                && person.Password!.Equals(_hasherService.GetHashPassword(user.Password, person.Salt)))
                return Results.Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Results.Text("Login succesful");
        }
    }
}
