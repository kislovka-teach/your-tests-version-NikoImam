using VariantOne.Abstractions;
using VariantOne.Entities;
using VariantOne.Extensioins;

namespace VariantOne
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

            app.MapPost("/login", async(HttpContext context, IUserService userService, User user) =>
            {
                return await userService.Authorize(user, context);
            });

            app.MapGroup("/tea")
                .TeaGroup();

            app.MapGroup("/product")
                .ProductGroup();

            app.MapGroup("/order")
                .OrderGroup();

            app.Run();
        }
    }
}
