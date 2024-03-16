using Microsoft.AspNetCore.Authorization;
using VariantTwo.Abstractions;
using VariantTwo.Models.RequestModels;

namespace VariantTwo.Extensioins
{
    public static class Groups
    {
        public static RouteGroupBuilder CarModelGroup(this RouteGroupBuilder builder)
        {
            builder.MapPost("/add", [Authorize(Roles = "Admin")] async (CarModel carModel, ICarModelRepository carModelRepository) =>
            {
                await carModelRepository.AddCarModel(carModel);
                return Results.Ok();
            });

            return builder;
        }

        public static RouteGroupBuilder CarGroup(this RouteGroupBuilder builder)
        {
            builder.MapPost("/add", [Authorize(Roles = "User")] async (HttpContext context, Car car, ICarRepository carRepository, IUserService userService) =>
            {
                car.OwnerId = await userService.GetUserId(context);
                await carRepository.AddCar(car);
                return Results.Ok();
            });

            return builder;
        }

        public static RouteGroupBuilder ArticleGroup(this RouteGroupBuilder builder)
        {
            builder.MapPost("/add", [Authorize(Roles = "User")] async(HttpContext context, Article article, IArticleRepository articleRepository, IUserService userService) =>
            {
                article.AuthorId = await userService.GetUserId(context);
                await articleRepository.AddArticle(article);
                return Results.Ok();
            });

            builder.MapGet("/{id:int}", async (int id, IArticleRepository articleRepository) =>
            {
                return Results.Json(await articleRepository.GetArticle(id));
            });

            builder.MapGet("/all", async (IArticleRepository articleRepository) =>
            {
                return Results.Json(await articleRepository.GetAllArticles());
            });

            builder.MapGet("/top", async (int count, IArticleRepository articleRepository) =>
            {
                return Results.Json(await articleRepository.GetFirstTopArticles(count));
            });

            builder.MapPost("/{id:int}/comment/add", [Authorize(Roles = "User")] async (int id, HttpContext context, Comment comment, IArticleService articleService, IUserService userService) =>
            {
                comment.ArticleId = id;
                comment.UserId = await userService.GetUserId(context);
                await articleService.AddComment(comment);
                return Results.Ok();
            });

            builder.MapPost("/{id:int}/vote", [Authorize(Roles = "User")] async (int id, IArticleService articleService) =>
            {
                await articleService.Vote(id);
            });

            return builder;
        }
    }
}
