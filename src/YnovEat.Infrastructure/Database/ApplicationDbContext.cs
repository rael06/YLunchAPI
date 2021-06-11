using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantUser> RestaurantUsers { get; set; }
        public DbSet<ClosingDate> ClosingDates { get; set; }
        public DbSet<DayOpeningHours> DayOpeningHours { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RestaurantProduct> RestaurantProducts { get; set; }
        public DbSet<RestaurantProductTag> RestaurantProductTags { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(x =>
            {
                x.Property(c => c.UserName).IsRequired();
                x.Property(c => c.Firstname).IsRequired();
                x.Property(c => c.Lastname).IsRequired();
            });

            builder.Entity<ClosingDate>(x => { x.Property(c => c.ClosingDateTime).IsRequired(); });

            builder.Entity<DayOpeningHours>(x =>
            {
                x.HasMany(d => d.OpeningHours)
                    .WithOne(o => o.DayOpeningHours);

                x.Property(d => d.DayOfWeek).IsRequired();
            });

            builder.Entity<OpeningHour>(x =>
            {
                x.Property(oh => oh.StartHourInMinutes).IsRequired();
                x.Property(oh => oh.EndHourInMinutes).IsRequired();
            });

            builder.Entity<OrderStatus>(x =>
            {
                x.Property(os => os.Status).IsRequired();
                x.Property(os => os.DateTime).IsRequired();
            });

            builder.Entity<RestaurantCategory>(x => { x.Property(rc => rc.Name).IsRequired(); });

            builder.Entity<RestaurantProduct>(x =>
            {
                x.Property(rp => rp.Name).IsRequired();
                x.Property(rp => rp.Price).IsRequired();
                x.Property(rp => rp.Quantity).IsRequired();
                x.Property(rp => rp.IsActive).IsRequired();
                x.Property(rp => rp.CreationDateTime).IsRequired();
                x.Property(rp => rp.ProductFamily).IsRequired();
            });

            builder.Entity<CustomerProduct>(x =>
            {
                x.Property(cp => cp.Name).IsRequired();
                x.Property(cp => cp.Price).IsRequired();
                x.Property(cp => cp.CreationDateTime).IsRequired();
                x.Property(cp => cp.RestaurantProductId).IsRequired();
            });

            builder.Entity<RestaurantProductTag>(x => { x.Property(rpt => rpt.Name).IsRequired(); });

            builder.Entity<Restaurant>(x =>
            {
                x.HasMany(r => r.DaysOpeningHours)
                    .WithOne(d => d.Restaurant);

                x.HasMany(r => r.ClosingDates)
                    .WithOne(d => d.Restaurant);

                x.HasMany(r => r.Products)
                    .WithOne(p => p.Restaurant);

                x.HasOne(r => r.Owner)
                    .WithOne(ru => ru.Restaurant)
                    .HasForeignKey<Restaurant>(r => r.RestaurantOwnerId);
            });

            builder.Entity<RestaurantUser>(x =>
            {
                x.HasKey(ro => ro.Id);

                x.HasOne(ru => ru.User)
                    .WithOne(u => u.RestaurantUser)
                    .HasForeignKey<RestaurantUser>(u => u.Id);
            });

            builder.Entity<Customer>(x =>
            {
                x.HasOne(c => c.User)
                    .WithOne(u => u.Customer)
                    .HasForeignKey<Customer>(c => c.Id);

                x.HasMany(c => c.Orders)
                    .WithOne(o => o.Customer);

                x.Property(c => c.CustomerFamily).IsRequired();
            });

            builder.Entity<Cart>(x =>
            {
                x.HasOne(c => c.Customer)
                    .WithOne(u => u.Cart)
                    .HasPrincipalKey<Customer>(c => c.Id);
            });

            builder.Entity<Order>(x =>
            {
                x.HasMany(o => o.OrderStatuses)
                    .WithOne(os => os.Order);

                x.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId);

                x.Ignore(o => o.RestaurantProducts);
            });

            base.OnModelCreating(builder);
        }
    }
}
