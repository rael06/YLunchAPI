using System.Threading.Tasks;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.Services.OrderServices
{
    public interface IOrderRepository
    {
        Task Create(Order order);
    }
}