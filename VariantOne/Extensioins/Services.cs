using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using VariantOne.Abstractions;
using VariantOne.Configurations.Mapping;
using VariantOne.DbContexts;
using VariantOne.Services;

namespace VariantOne.Extensioins
{
    public static class Services
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("ConnectionToPostgres");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<OrderMapperProfile>();
                cfg.AddProfile<ProductMapperProfile>();
                cfg.AddProfile<ReviewMapperProfile>();
                cfg.AddProfile<TeaMapperProfile>();
            });

            builder.Services.AddScoped<IHasherService, HasherService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<ITeaRepository, TeaRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts => opts.LoginPath = "/login");
            builder.Services.AddAuthorization();
        }
    }
}
