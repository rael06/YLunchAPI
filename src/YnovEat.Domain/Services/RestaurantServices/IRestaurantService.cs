using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.RestaurantModels;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.Services.RestaurantServices
{
    public interface IRestaurantService
    {
        Task<RestaurantReadDto> Create(RestaurantCreationDto restaurantCreationDto, CurrentUser currentUser);
        Task<RestaurantReadDto> Update(RestaurantModificationDto restaurantModificationDto,
            Restaurant restaurantReadDto);
        Task<RestaurantReadDto> GetById(string id);
        Task<RestaurantReadDto> GetByUserId(string currentUserId);
        Task<ICollection<RestaurantReadDto>> GetAllForCustomer();
        Task<ICollection<RestaurantReadDto>> GetAllRestaurants();
    }
}
