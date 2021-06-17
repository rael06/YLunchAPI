using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Services.Database.Repositories;

namespace YnovEat.Infrastructure.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
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
                .Where(x => x.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
