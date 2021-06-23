using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.OrderModels;
using YnovEat.Domain.DTO.RestaurantModels;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.RestaurantAggregate;

namespace YnovEat.Domain.Services.RestaurantServices
{
    public interface IRestaurantService
    {
        Task<RestaurantReadDto> Create(RestaurantCreationDto restaurantCreationDto, CurrentUser currentUser);
        Task<RestaurantReadDto> Update(RestaurantModificationDto restaurantModificationDto,
            Restaurant restaurantReadDto);
        Task UpdateIsPublished(string restaurantId);
        Task<RestaurantReadDto> GetById(string id);
        Task<RestaurantReadDto> GetByUserId(string currentUserId);
        Task<ICollection<RestaurantReadDto>> GetAllForCustomer();
        Task<ICollection<RestaurantReadDto>> GetAllRestaurants();
        Task<ICollection<OrderReadDto>> GetTodayOrders(string restaurantId);
    }
}
