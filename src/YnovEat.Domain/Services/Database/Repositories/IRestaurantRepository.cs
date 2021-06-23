using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.Services.Database.Repositories
{
    public interface IRestaurantRepository
    {
        Task Create(Restaurant restaurant);
        Task Update();
        Task<Restaurant> GetById(string id);
        Task<Restaurant> GetByUserId(string currentUserId);
        Task<ICollection<RestaurantCategory>> GetAllRestaurantCategories();
        Task<ICollection<Restaurant>> GetAllForCustomer();
        Task<ICollection<Restaurant>> GetAll();
        Task<Restaurant> GetByIdIncludingProducts(string modelId);
    }
}
