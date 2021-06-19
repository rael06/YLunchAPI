using System.Threading.Tasks;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Services.OrderServices;

namespace YnovEat.Infrastructure.Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
