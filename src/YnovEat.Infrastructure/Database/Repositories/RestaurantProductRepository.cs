using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Services.Database.Repositories;

namespace YnovEat.Infrastructure.Database.Repositories
{
    public class RestaurantProductRepository : IRestaurantProductRepository
    {
        private readonly ApplicationDbContext _context;

        public RestaurantProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(RestaurantProduct restaurantProduct)
        {
            await _context.RestaurantProducts.AddAsync(restaurantProduct);
            await _context.SaveChangesAsync();
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<RestaurantProduct>> GetAllByRestaurantId(string restaurantId)
        {
            return await _context.RestaurantProducts
                .Where(x => x.RestaurantId.Equals(restaurantId))
                .ToListAsync();
        }

        public async Task<ICollection<RestaurantProduct>> GetAllForCustomerByRestaurantId(string restaurantId)
        {
            return await _context.RestaurantProducts
                .Where(x => x.RestaurantId.Equals(restaurantId))
                .Where(x => x.IsActive)
                .ToListAsync();
        }

        public async Task Delete(string restaurantProductId)
        {
            var restaurantProduct =
                await _context.RestaurantProducts.FirstOrDefaultAsync(x => x.Id.Equals(restaurantProductId));
            _context.RestaurantProducts.Remove(restaurantProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<RestaurantProduct>> GetAllEligibleForCustomerByRestaurantIdByProductIds(ICollection<string> orderedRestaurantProductsIds,
            string restaurantId)
        {
            var restaurantProducts =
                await GetAllForCustomerByRestaurantId(restaurantId);

            return orderedRestaurantProductsIds
                .Where(id => restaurantProducts.Any(rp=> rp.Id.Equals(id)))
                .Select(id=> _context.RestaurantProducts.Find(id))
                .ToList();
        }
    }
}
