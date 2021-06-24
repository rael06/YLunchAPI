using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.Services.OrderServices;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

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

        public async Task<ICollection<Order>> GetAllByRestaurantId(string restaurantId)
        {
            return await _context.Orders
                .Include(x => x.OrderStatuses)
                .Include(x => x.CustomerProducts)
                .Where(o => o.RestaurantId.Equals(restaurantId))
                .Where(o => o.CreationDateTime > DateTime.Today)
                .OrderBy(o=>o.ReservedForDateTime)
                .ToListAsync();
        }

        public async Task<Order> GetById(string id)
        {
            return await _context.Orders
                .Include(x => x.OrderStatuses)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> GetAllByIds(ICollection<string> ordersId)
        {
            return await _context.Orders
                .Include(x => x.OrderStatuses)
                .Where(o => ordersId.Contains(o.Id))
                .OrderBy(o=>o.ReservedForDateTime)
                .ToListAsync();
        }

        public async Task<ICollection<Order>> GetNewOrdersByRestaurantId(string restaurantId)
        {
            return await _context.Orders
                .Include(x => x.OrderStatuses)
                .Where(x => x.RestaurantId.Equals(restaurantId))
                .Where(x => x.OrderStatuses.All(y => y.State == OrderState.Idling))
                .OrderBy(o=>o.ReservedForDateTime)
                .ToListAsync();
        }
    }
}
