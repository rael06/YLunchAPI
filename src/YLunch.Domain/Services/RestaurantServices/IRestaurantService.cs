using System.Collections.Generic;
using System.Threading.Tasks;
using YLunch.Domain.DTO.OrderModels;
using YLunch.Domain.DTO.RestaurantModels;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.ModelsAggregate.RestaurantAggregate;

namespace YLunch.Domain.Services.RestaurantServices
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
