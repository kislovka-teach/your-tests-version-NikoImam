using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VariantTwo.Abstractions;
using VariantTwo.Configurations.Mapping;
using VariantTwo.DbContexts;
using VariantTwo.Services;

namespace VariantTwo.Extensioins
{
    public static class Services
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("ConnectionToPostgres");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CarModelMapperProfile>();
                cfg.AddProfile<CarMapperProfile>();
                cfg.AddProfile<ArticleMapperProfile>();
                cfg.AddProfile<CommentMapperProfile>();
            });

            builder.Services.AddScoped<IHasherService, HasherService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
            builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IArticleService, ArticleService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.SymmetricSecurityKey,
                    ValidateIssuerSigningKey = true
                };
            });

            builder.Services.AddAuthorization();
        }
    }

    static class AuthOptions
    {
        public const string Issuer = "AuthServer";
        public const string Audience = "AuthClient";
        const string Secret = "hardbass007hohohohohohohohoohohohohoohohohohohohohohohohohohoohohohohoejgneijgneriapjfnpiaerngpivferfjaS";
        public static SymmetricSecurityKey SymmetricSecurityKey
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            }
        }
    }
}
