using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VariantTwo.Abstractions;
using VariantTwo.Entities;
using VariantTwo.Extensioins;

namespace VariantTwo.Services
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

        public async Task<IResult> Authorize(User userR, HttpContext context)
        {
            var username = userR.Username;
            var password = userR.Password;

            var user = await _userRepository.GetUser(username!);

            if (user is null || !user.Password!.Equals(_hasherService.GetHashPassword(password, user!.Salt))) return Results.Unauthorized();

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username!),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(AuthOptions.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                AccessToken = encodedJwt
            };

            return Results.Json(response);
        }

        public async Task<int> GetUserId(HttpContext context)
        {
            return (await _userRepository.GetUser(context.User.FindFirst(ClaimTypes.Name)!.Value))!.Id;
        }
    }
}
