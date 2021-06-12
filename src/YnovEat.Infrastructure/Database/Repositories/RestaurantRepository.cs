using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
            await QueryEnrichedRestaurant
                .FirstOrDefaultAsync(x=>x.Id.Equals(id));

        private IIncludableQueryable<Restaurant, ICollection<DayOpeningTimes>> QueryEnrichedRestaurant =>
            _context.Restaurants
                .Include(x => x.ClosingDates)
                .Include(x => x.WeekOpeningTimes);

        public async Task<Restaurant> GetByOwnerId(string id) =>
            await QueryEnrichedRestaurant
                .FirstOrDefaultAsync(x=>x.OwnerId.Equals(id));

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

            var existingWeekOpeningTimes =
                await _context.DaysOpeningTimes.Where(x => x.RestaurantId.Equals(restaurant.Id)).ToListAsync();
            var existingDaysOpeningTimesIds = existingWeekOpeningTimes.Select(x => x.Id).ToList();
            var existingOpeningTimes =
                await _context.OpeningTimes.Where(x => existingDaysOpeningTimesIds.Contains(x.DayOpeningTimesId)).ToListAsync();

            _context.OpeningTimes.RemoveRange(existingOpeningTimes);
            _context.DaysOpeningTimes.RemoveRange(existingWeekOpeningTimes);

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
