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
        public DbSet<ClosingDate> ClosingDates { get; set; }
        public DbSet<DayOpeningHours> DayOpeningHours { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public DbSet<Restaurant_RestaurantCategory> Restaurant_RestaurantCategory_Links { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RestaurantProduct> RestaurantProducts { get; set; }
        public DbSet<RestaurantProductCategory> RestaurantProductCategories { get; set; }

        public DbSet<RestaurantProduct_RestaurantProductCategory> RestaurantProduct_RestaurantProductCategory_Links
        {
            get;
            set;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DayOpeningHours>()
                .HasMany(d => d.OpeningHours)
                .WithOne(o => o.DayOpeningHours);

            builder.Entity<Restaurant>()
                .HasOne(r => r.MainAdmin)
                .WithOne(u => u.Restaurant)
                .HasForeignKey<Restaurant>(r=>r.MainAdminId);

            builder.Entity<Restaurant>()
                .HasMany(r => r.DaysOpeningHours)
                .WithOne(d => d.Restaurant);

            builder.Entity<Restaurant>()
                .HasMany(r => r.ClosingDates)
                .WithOne(d => d.Restaurant);

            builder.Entity<Restaurant>()
                .HasMany(r => r.Products)
                .WithOne(p => p.Restaurant);

            builder.Entity<Restaurant_RestaurantCategory>()
                .HasKey(x => new {x.RestaurantId, x.RestaurantCategoryId});

            builder.Entity<Restaurant>()
                .HasMany(r => r.ProductCategories)
                .WithOne(p => p.Restaurant);

            builder.Entity<RestaurantProduct_RestaurantProductCategory>()
                .HasKey(x => new {x.RestaurantProductId, x.RestaurantProductCategoryId});

            builder.Entity<Customer>()
                .HasKey(c => c.UserId);

            builder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne(c => c.User)
                .HasPrincipalKey<Customer>(c=>c.UserId);

            builder.Entity<Customer>()
                .HasOne(c => c.CustomerCategory)
                .WithMany(cc => cc.Customer);

            builder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer);

            builder.Entity<Order>()
                .HasMany(o => o.OrderStatuses)
                .WithOne(os => os.Order);

            builder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o=>o.CustomerId);

            base.OnModelCreating(builder);
        }
    }
}
