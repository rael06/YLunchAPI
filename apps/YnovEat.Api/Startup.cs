using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using YnovEat.Application.Services;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.Registration;
using YnovEat.Infrastructure.Database;
using YnovEat.Infrastructure.Database.Repositories;

namespace YnovEat.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "YnovEat", Version = "v1"}); });

            // For Entity Framework
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    "Server=127.0.0.1;Port=3306;Database=ynoveatdb;Uid=root;Pwd=" + Configuration["DbPassword"] + ";",
                    new MySqlServerVersion(new Version(8, 0, 11)),
                    b => b.MigrationsAssembly("YnovEat.Api")));

            // For Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })

                // Adding Jwt Bearer
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecret"]))
                    };
                });

            // Cors
            // TODO customize Cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            // Application Services
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YnovEatApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
