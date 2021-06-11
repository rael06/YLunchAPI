using System.Threading.Tasks;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.Services.Database.Repositories
{
    public interface IRestaurantRepository
    {
        Task AddAdmin(User user);
        Task CreateRestaurant();
    }
}
