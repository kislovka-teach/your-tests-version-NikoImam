using VariantTwo.Abstractions;
using VariantTwo.Entities;
using VariantTwo.Extensioins;

namespace VariantTwo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddServices();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapPost("/signup", async (User user, IUserService userService) =>
            {
                if (await userService.Registrate(user)) return Results.Ok();
                else return Results.BadRequest();
            });

            app.MapPost("/login", async (User userR, IUserService userService, HttpContext context) =>
            {
                return await userService.Authorize(userR, context);
            });

            app.MapGroup("/model")
                .CarModelGroup();

            app.MapGroup("/car")
                .CarGroup();

            app.MapGroup("/article")
                .ArticleGroup();

            app.Run();
        }
    }
}
