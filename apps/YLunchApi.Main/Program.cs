using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using YLunchApi.Application.RestaurantAggregate;
using YLunchApi.Application.UserAggregate;
using YLunchApi.Authentication.Models;
using YLunchApi.Authentication.Repositories;
using YLunchApi.Authentication.Services;
using YLunchApi.AuthenticationShared.Repositories;
using YLunchApi.Domain.CommonAggregate.Dto;
using YLunchApi.Domain.CommonAggregate.Services;
using YLunchApi.Domain.RestaurantAggregate.Services;
using YLunchApi.Domain.UserAggregate.Models;
using YLunchApi.Domain.UserAggregate.Services;
using YLunchApi.Infrastructure.Database;
using YLunchApi.Infrastructure.Database.Repositories;
DotNetEnv.Env.Load();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.TryAddScoped(_ => new JwtSecurityTokenHandler());
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IAllergenRepository, AllergenRepository>();
builder.Services.AddScoped<IProductTagRepository, ProductTagRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For Identity
builder.Services.AddIdentity<User, IdentityRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddDefaultTokenProviders();

// For Jwt
var jwtSecret = Environment.GetEnvironmentVariable("JwtSecret");
if (string.IsNullOrEmpty(jwtSecret))
{
    throw new InvalidOperationException("JwtSecret is not set. Check your .env file or environment variables.");
}

var key = Encoding.ASCII.GetBytes(jwtSecret);
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    RequireExpirationTime = false,

    // Allow to use seconds for expiration of token
    // Required only when token lifetime less than 5 minutes
    ClockSkew = TimeSpan.Zero
};
builder.Services.AddSingleton(tokenValidationParameters);
builder.Services.Configure<JwtConfig>(jwtConfig => jwtConfig.Secret = jwtSecret);
builder.Services.AddAuthentication(options =>
       {
           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       })
       .AddJwtBearer(options =>
       {
           options.SaveToken = true;
           options.TokenValidationParameters = tokenValidationParameters;
           options.Events = new JwtBearerEvents
           {
               OnForbidden = context =>
               {
                   context.Response.OnStarting(async () =>
                   {
                       context.Response.StatusCode = StatusCodes.Status403Forbidden;
                       context.Response.ContentType = "application/json";
                       await context.Response.WriteAsJsonAsync(new ErrorDto(HttpStatusCode.Forbidden,
                           "User has not granted roles."));
                   });

                   return Task.CompletedTask;
               },
               OnChallenge = context =>
               {
                   context.Response.OnStarting(async () =>
                   {
                       context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                       context.Response.ContentType = "application/json";
                       await context.Response.WriteAsJsonAsync(new ErrorDto(HttpStatusCode.Unauthorized,
                           "Please login and use provided tokens."));
                   });

                   return Task.CompletedTask;
               }
           };
       });

// For Entity Framework
var dbName = Environment.GetEnvironmentVariable("DbName");
if (string.IsNullOrEmpty(dbName))
{
    throw new InvalidOperationException("DbName is not set. Check your .env file or environment variables.");
}

var dbUser = Environment.GetEnvironmentVariable("DbUser");
if (string.IsNullOrEmpty(dbUser))
{
    throw new InvalidOperationException("DbUser is not set. Check your .env file or environment variables.");
}

var dbPassword = Environment.GetEnvironmentVariable("DbPassword");
if (string.IsNullOrEmpty(dbPassword))
{
    throw new InvalidOperationException("DbPassword is not set. Check your .env file or environment variables.");
}

var dbHost = Environment.GetEnvironmentVariable("DbHost");
if (string.IsNullOrEmpty(dbHost))
{
    throw new InvalidOperationException("DbHost is not set. Check your .env file or environment variables.");
}

var dbPort = Environment.GetEnvironmentVariable("DbPort");
if (string.IsNullOrEmpty(dbPort))
{
    throw new InvalidOperationException("DbPort is not set. Check your .env file or environment variables.");
}

var connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};User={dbUser};Password={dbPassword};";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        b => b.MigrationsAssembly("YLunchApi.Main")
    );
});

// Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin();
        corsPolicyBuilder.AllowAnyHeader();
        corsPolicyBuilder.WithMethods(
            HttpMethods.Post,
            HttpMethods.Get,
            HttpMethods.Patch,
            HttpMethods.Put,
            HttpMethods.Delete
        );
    });
});

// ------------------------ MIDDLEWARES ------------------------

// Allow static files to serve yaml
var app = builder.Build();
var provider = new FileExtensionContentTypeProvider
{
    Mappings =
    {
        [".yaml"] = "application/x-yaml"
    }
};
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger-original.yaml", "Simple Inventory API Original"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.Urls.Add("http://localhost:5258");
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new ErrorDto(HttpStatusCode.InternalServerError,
                "Something went wrong, try again later."));
        });
    });
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}
