using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.Services.Database.Repositories
{
    public interface IProductRepository
    {
        Task Create(RestaurantProduct restaurantProduct);
        Task Update();
        Task<ICollection<RestaurantProduct>> GetAllByRestaurantId(string restaurantId);
    }
}
