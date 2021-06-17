using System.Threading.Tasks;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.Services.Database.Repositories
{
    public interface IProductRepository
    {
        Task Create(RestaurantProduct restaurantProduct);
        Task Update();
    }
}
