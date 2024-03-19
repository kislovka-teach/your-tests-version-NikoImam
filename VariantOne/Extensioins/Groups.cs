using Microsoft.AspNetCore.Authorization;
using VariantOne.Abstractions;
using VariantOne.Services;

namespace VariantOne.Extensioins
{
    public static class Groups
    {
        public static RouteGroupBuilder TeaGroup(this RouteGroupBuilder builder)
        {
            builder.MapPost("/add", [Authorize(Roles = "admin")] async (Models.RequestModels.Tea tea, ITeaRepository teaRepository) =>
            {
                await teaRepository.AddTea(tea);
            });

            return builder;
        }

        public static RouteGroupBuilder ProductGroup(this RouteGroupBuilder builder)
        {
            builder.MapPost("/add", [Authorize(Roles = "admin")] async (Models.RequestModels.Product product, IProductRepository productRepository) =>
            {
                await productRepository.AddProduct(product);
                return Results.Ok();
            });

            builder.MapGet("/all", async (IProductRepository productRepository) =>
            {
                return Results.Json(await productRepository.GetAllProduct());
            });

            return builder;
        }

        public static RouteGroupBuilder OrderGroup(this RouteGroupBuilder builder)
        {
            builder.MapPost("/add", [Authorize] async (Models.RequestModels.Order order, IOrderService orderService) =>
            {
                await orderService.AddOrder(order);
                return Results.Ok();
            });

            builder.MapPost("/{id:int}/setstatus", [Authorize(Roles = "admin")] async (IOrderService orderService, Models.RequestModels.Order order, int id) =>
            {
                await orderService.SetStatus(id, order.Status);
                return Results.Ok();
            });

            builder.MapPost("/{id:int}/pay", [Authorize] async (IOrderService orderService, Models.RequestModels.Order order, int id) =>
            {
                if (await orderService.PayOrder(id, order.TotalPrice)) return Results.Ok();
                else return Results.BadRequest();
            });

            builder.MapPost("/{id:int}/review/add", [Authorize] async (IReviewService reviewService, int id, Models.RequestModels.Review review) =>
            {
                await reviewService.AddReview(review);
                return Results.Ok();
            });

            return builder;
        }
    }
}
