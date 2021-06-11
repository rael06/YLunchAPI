using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.Services.Database.Repositories;

namespace YnovEat.Infrastructure.Database.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> GetById(string id) =>
            await _context.Restaurants.FindAsync(id);

        public async Task AddAdmin(User user)
        {
            await _context.RestaurantUsers.AddAsync(new RestaurantOwner
            {
                Id = user.Id,
                User = user
            });
            await _context.SaveChangesAsync();
        }

        public async Task<Restaurant> UpdateRestaurant(Restaurant restaurant)
        {
            var existingClosingDates =
                await _context.ClosingDates.Where(x => x.RestaurantId.Equals(restaurant.Id)).ToListAsync();
            _context.ClosingDates.RemoveRange(existingClosingDates);

            var restaurantDb = await _context.Restaurants.FindAsync(restaurant.Id);
            restaurantDb.Name = restaurant.Name;
            restaurantDb.PhoneNumber = restaurant.PhoneNumber;
            restaurantDb.Email = restaurant.Email;
            restaurantDb.IsOpen = restaurant.IsOpen;
            restaurantDb.ZipCode = restaurant.ZipCode;
            restaurantDb.Country = restaurant.Country;
            restaurantDb.City = restaurant.City;
            restaurantDb.StreetNumber = restaurant.StreetNumber;
            restaurantDb.StreetName = restaurant.StreetName;
            restaurantDb.AddressExtraInformation = restaurant.AddressExtraInformation;
            restaurantDb.ClosingDates = restaurant.ClosingDates;

            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<Restaurant> CreateRestaurant(Restaurant restaurant)
        {
            var owner = await _context.RestaurantUsers.FirstAsync(x => x.User.Id.Equals(restaurant.OwnerId));
            owner.RestaurantId = restaurant.Id;
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }
    }
}
