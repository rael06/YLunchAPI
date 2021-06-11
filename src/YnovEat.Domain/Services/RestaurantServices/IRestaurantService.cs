using System.Threading.Tasks;
using YnovEat.Domain.DTO.RestaurantModels;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.Services.RestaurantServices
{
    public interface IRestaurantService
    {
        Task<RestaurantReadDto> Create(RestaurantCreationDto restaurantCreationDto, CurrentUser currentUser);
        Task<RestaurantReadDto> Update(RestaurantModificationDto restaurantModificationDto);
        Task<RestaurantReadDto> GetById(string id);
    }
}
