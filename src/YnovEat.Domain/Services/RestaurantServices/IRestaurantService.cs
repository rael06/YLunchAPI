using System.Threading.Tasks;
using YnovEat.Domain.DTO.RestaurantModels;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.Services.RestaurantServices
{
    public interface IRestaurantService
    {
        Task Create(RestaurantCreationDto restaurantCreationDto, CurrentUser currentUser);
    }
}
