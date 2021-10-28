using System.Collections.Generic;
using System.Threading.Tasks;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.Services.Database.Repositories
{
    public interface IRestaurantProductRepository
    {
        Task Create(RestaurantProduct restaurantProduct);
        Task Update();
        Task<ICollection<RestaurantProduct>> GetAllByRestaurantId(string restaurantId);
        Task<ICollection<RestaurantProduct>> GetAllForCustomerByRestaurantId(string restaurantId);
        Task Delete(string restaurantProductId);
        Task<ICollection<RestaurantProduct>> GetAllEligibleForCustomerByRestaurantIdByProductIds(ICollection<string> orderedRestaurantProductsIds, string restaurantId);
    }
}
