using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Infrastructure.Database
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Restaurants)
                .WithOne(r => r.User);

            builder.Entity<DayOpeningHours>()
                .HasMany(d => d.OpeningHours)
                .WithOne(o => o.DayOpeningHours);

            builder.Entity<Restaurant>()
                .HasMany(r => r.DaysOpeningHours)
                .WithOne(d => d.Restaurant);

            builder.Entity<Restaurant>()
                .HasMany(r => r.ClosingDates)
                .WithOne(d => d.Restaurant);

            base.OnModelCreating(builder);
        }
    }
}
